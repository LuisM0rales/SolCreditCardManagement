--------------------------------------------------------------------
--	Name		Version			Comment
--	Luis		1.0				Comentario Inicial
--------------------------------------------------------------------
CREATE OR ALTER PROCEDURE dbo.StatementDataCreditCard
(
	@CreditCardId INT
)
AS
BEGIN

DECLARE @ConfigMinBalanceRate DECIMAL = (SELECT CAST(ConfigurationVal AS DECIMAL) FROM GlobalConfigurations (NOLOCK) WHERE Code='MPIR')

	SELECT 
		Id							= a.Id
		,CardNumMask				= CONCAT(LEFT(a.CardNumber,4),' **** **** ',RIGHT(a.CardNumber,4))
		,Name						= a.EmbossedName
		,CurrentBalance				= CAST(ISNULL(CurrentMonthPurchase.Amount, 0.00) AS DECIMAL(18,2))
		,AvailableBalance			= CAST(ISNULL((a.LimitCard-(CurrentMonthPurchase.Amount-CurrentMonthPayments.Amount)), 0.00) AS DECIMAL(18,2))
		,CreditLimit				= CAST(ISNULL(a.LimitCard, 0.00) AS DECIMAL(18,2))
		,InterestRate				= CAST(ISNULL(a.InterestRate, 0.00) AS DECIMAL(18,2))
		,MinInterestRate			= CAST(ISNULL(@ConfigMinBalanceRate, 0.00) AS DECIMAL(18,2))
		,MinAmountPay				= CAST(ISNULL((CurrentMonthPurchase.Amount*@ConfigMinBalanceRate), 0.00) AS DECIMAL(18,2))
		,RedeemableInterest			= CAST(ISNULL((CurrentMonthPurchase.Amount*a.InterestRate), 0.00) AS DECIMAL(18,2))
		,TotalCurrentMonthPurchase	= CAST(ISNULL(CurrentMonthPurchase.Amount, 0.00) AS DECIMAL(18,2))
		,TotalPreviousMonthPurchase	= CAST(ISNULL(PreviousMonthPurchase.Amount, 0.00) AS DECIMAL(18,2))
		,CreatedDate				= GETDATE()
		,UpdatedDate				= GETDATE()
	FROM CreditCards (NOLOCK)				a
		INNER JOIN Customers (NOLOCK)		b ON a.CustomerId=b.Id
	
		OUTER APPLY (
			SELECT SUM(t.Amount) Amount
			FROM Transactions (NOLOCK) t
				INNER JOIN TransactionTypes (NOLOCK) b ON (t.TransactionTypeId=b.Id AND b.TransactionTypeCode='PURCH')
			WHERE MONTH(t.CreatedDate) = MONTH(GETDATE())
				AND YEAR(t.CreatedDate) = YEAR(GETDATE())
				AND t.CreditCardId=a.Id
		)CurrentMonthPurchase

		OUTER APPLY (
			SELECT SUM(t.Amount) Amount
			FROM Transactions (NOLOCK) t
				INNER JOIN TransactionTypes (NOLOCK) b ON (t.TransactionTypeId=b.Id AND b.TransactionTypeCode='PAYM')
			WHERE MONTH(t.CreatedDate) = MONTH(GETDATE())
				AND YEAR(t.CreatedDate) = YEAR(GETDATE())
				AND t.CreditCardId=a.Id
		)CurrentMonthPayments

		OUTER APPLY (
			SELECT SUM(t.Amount) Amount
			FROM Transactions (NOLOCK) t
				INNER JOIN TransactionTypes (NOLOCK) b ON (t.TransactionTypeId=b.Id AND b.TransactionTypeCode='PURCH')
			WHERE MONTH(t.CreatedDate) = MONTH(DATEADD(MONTH,-1,GETDATE()))
				AND YEAR(t.CreatedDate) = YEAR(GETDATE())
				AND t.CreditCardId=a.Id
		)PreviousMonthPurchase
	WHERE a.Id=@CreditCardId
END
/*
EXEC dbo.StatementDataCreditCard 1
*/