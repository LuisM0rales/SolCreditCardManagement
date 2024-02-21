using AutoMapper;
using SolCreditCardManagement.Application.Features.CreditCards.Commands.CreateCreditCard;
using SolCreditCardManagement.Application.Features.CreditCards.Commands.UpdateCreditCard;
using SolCreditCardManagement.Application.Features.CreditCards.Queries.GetCreditCardsList;
using SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.CreateCreditCardStatuses;
using SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.UpdateCreditCardStatuses;
using SolCreditCardManagement.Application.Features.CreditCardStatuses.Queries.GetCreditCardStatusesList;
using SolCreditCardManagement.Application.Features.Customers.Commands.CreateCustomer;
using SolCreditCardManagement.Application.Features.Customers.Commands.UpdateCustomer;
using SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList;
using SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.CreateGlobalConfigurations;
using SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.UpdateGlobalConfigurations;
using SolCreditCardManagement.Application.Features.GlobalConfigurations.Queries.GetGlobalConfigurationsList;
using SolCreditCardManagement.Application.Features.Statements.Queries.GetStatementByICreditCardId;
using SolCreditCardManagement.Application.Features.Transactions.Commands.CreateTransactions;
using SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList;
using SolCreditCardManagement.Application.Features.TransactionTypes.Commands.CreateTransactionTypes;
using SolCreditCardManagement.Application.Features.TransactionTypes.Commands.UpdateTransactionTypes;
using SolCreditCardManagement.Application.Features.TransactionTypes.Queries.GetTransactionTypesList;
using SolCreditCardManagement.Data;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreditCard, CreditCardVm>();
            CreateMap<CreateCreditCardCommand, CreditCard>();
            CreateMap<UpdateCreditCardCommand, CreditCard>();

            CreateMap<CreditCardStatus, CreditCardStatusVm>();
            CreateMap<CreateCreditCardStatusesCommand, CreditCardStatus>();
            CreateMap<UpdateCreditCardStatusesCommand, CreditCardStatus>();
            
            CreateMap<Customer, CustomerVm>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            
            CreateMap<GlobalConfiguration, GlobalConfigurationVm>();
            CreateMap<CreateGlobalConfigurationsCommand, GlobalConfiguration>();
            CreateMap<UpdateGlobalConfigurationsCommand, GlobalConfiguration>();
            
            CreateMap<Statement, StatementVm>();

            CreateMap<Transaction, TransactionVm>();
            CreateMap<CreateTransactionsCommand, Transaction>();

            CreateMap<TransactionType, TransactionTypeVm>();
            CreateMap<CreateTransactionTypesCommand, TransactionType>();
            CreateMap<UpdateCreateTransactionTypesCommand, TransactionType>();
        }
    }
}
