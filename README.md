
# Estado de cuenta tarjeta de credito
[![](https://skillicons.dev/icons?i=dotnet,cs,bootstrap,js,visualstudio,postman&perline=6)](https://skillicons.dev) 

[![Build](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/build.yml/badge.svg)](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/build.yml)

[![CodeQL](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/codeql.yml/badge.svg)](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/codeql.yml)

![2022](https://img.shields.io/badge/Sql-2022-blue?logo=microsoft-sql-server&logoColor=white)

Proyecto de estado de cuenta, muestra y exporta el estado de cuenta a Excel, PDF, etc, puedes configurar la tasa de interes

El proyecto se hizo en varias capas aplicando CleanArchitecture, las cuales son:

- `Capa de aplicacion`: la cual contiene las operaciones y modelos que definen la aplicacion segun caso de uso implementando CQRS.
- `Capa de dominio`: la cual contiene las entidades centrales y los objetos de negocio del dominio.
- `Capa de infraestructura`: esta capa nos ayuda en el acceso a los datos asi como tambien posibles servicios externos.
- `Capa de presentacion`: compuesta por una API y una WebApp para mostrar los datos de manera apropiada, comunicandose estos con la capa de aplicacion por medio de eventos atraves de pipelines.

## Pasos para ejecucion del proyecto:

Para configurar el proyecto es necesario seguir los siguientes pasos: 

1. Cambiar la Cadena de conexión: Dentro del proyecto de `~/API/SolCreditCardManagement.API` en el archivo appsettings.json 
actualizar la cadena de conexión a la base de datos por su servidor local SQL server.

2. Cambiar la URL del servicio: Dentro del proyecto `~/App/SolCreditCardManagement.App` en el archivo appsettings.json 
reemplazar la UrlApiBase, por la URL donde se levanta el proyecto `SolCreditCardManagement.API`.

3. Validar el orden de ejecucion de los proyectos, **click derecho en la solución > propiedades > Proyectos de inicio múltiple**: en la **primera posición** `SolCreditCardManagement.API`, en la **segunda posición** `SolCreditCardManagement.App`.
#
**Al ejecutar los proyectos, se ejecutará para la base de datos, esto permitirá la creación de la base de datos y sus tablas**
#

## Características de la capa de presentación
**Estado de cuenta**

Muestra las compras y el calculo del interés bonificable y el pago mínimo todo esto obtenido desde la api, la cual se realizo un SP para el manejo de cambios en los calculos de pago minimo que pueden existir en el futuro. adicional Permite exportar los datos a distintos tipos de archivos usando datatables con todos los detalles de las transacciones de compras.

**Crear compra**

Dicho formulario se envia los datos a la api la cual se encarga de generar el comando o query y mandarlo a la capa de aplicacion para sus respectivas validaciones dentro del pipeline, antes de llegar a la base de datos.

**Crear pagos**

Dicho formulario se envia los datos a la api la cual se encarga de generar el comando o query y mandarlo a la capa de aplicacion para sus respectivas validaciones dentro del pipeline, antes de llegar a la base de datos.

**Historico de transacciones**

Dicho pantalla muestra las transacciones realizadas por una tarjeta tanto pagos como compras.

### Bonus

**Mantenimiento de Configuraciones Globales**

Dicha pantalla muestra las configuraciones globales guardadas en la base de datos y dentro de ella se puede modificar y crear nuevas, en este **apartado se puede configurar una nueva tasa de interes pago minimo**.
