# ExamenVinnerenStoreGroup

# Instrucciones para correr la aplicacion
* Configurar las credenciales de Sql Server.
![configCredenciales](./imgReadme/configCredenciales.png)

* Marcar el proyecto WebApi como la **Set as startup project**
![setStartupProject](./imgReadme/setStartupProject.png)

* Correr la aplicacion 
    * `Nota. Al correr la aplicacion se generara automaticamente
la Base de Datos`
    * En caso de no generarse, entonces correr el comando **``Update-Database``** 
    desde package manager console.

# Arquitectura NCapas a utilizar

![arquitecturaNCapas](./imgReadme/arquitecturaNCapas.png)

# Modelo Entidad Relacion de nuestra DB
![dfEntidadRelacion](./imgReadme/dfEntidadRelacion.png)

# Paso para la creacion del proyecto.
* Nota. Cada proyecto a excepcion del WebApi, se crearan con
.NetStandart

* Nota. El nombre del proyecto lleva:
    * > nombreEmpresa.nombreAplicacion.nombreCapa.nombreCaracteristica
* * Nota. El nombre de la solucion lo dejamos como:
    * > nombreEmpresa.nombreAplicacion
![netStandart](./imgReadme/netStandart.png)

## Creamos el proyecto vacio y agregamos las siguientes carpetas
![initProject](./imgReadme/initProject.png)

## Creamos capa Transversal
* Common

## Creamos capa de infraescructura de persistencia de datos.
* Data 
    * Instalamos el paquete
        * Microsoft.EntityFrameworkCore.SqlServer
        * Microsoft.EntityFrameworkCore.Tools
    * Creo la clase de context que herede de DbContext.
* Interface
* Repository 

## Creamos capa Dominio
* Core
* Entity
* Interface

## Creamos capa Aplicacion
* Dto
* Interface
* Main

## Creamos capa de Servicios
* WebApi

## Generando Infraescructura en diferentes capas(Aplicacion, Dominio, Persistencia de datos)

* Creamos todas las entitys en la capa de Dominio.Entity y algunas interfaces en Dominio.entity.

* Modifico el startup y el programa para configurar la migracion

* Configuro AutoMapper

* Creo todos los Dtos por tabla en capa de aplicacion.

* Creo mi interfaz y clase de UnitOfWork
    * > IUnitOfWork
    * > UnitOfWork : IUnitOfWork

* Creo mi interfaz de repositorio generico
    * > IRepositoryGenericTEntity

* Creo mi repositorio generico
    * > RepositoryGenericTEntity

* Creo mi interfaz de repo para tabla Category que implemente del 
repo generico
    * > ICategoryRepo<TEntity> : IRepositoryGenericTEntity<TEntity>

* Creo mi repositorio para la tabla Category e implemento y codifico todos los metodos
    * > CategoryRepo<TEntity> : ICategoryRepo<TEntity> where TEntity : class
* De la misma forma que cree ICategoryRepo y CategoryRepo asi sigo
construyendo los repositorios para las demas tablas.

* A la interfaz IUnitOfWork establesco los repositorios que tendra
la clase UnitOfWork e implemento los repositorios.

* Creo mis interfaces vacias de CategoryApplication, CategoryDomain, CategoryController

* Creo mi clase ResResponse

* Creo mi clase BusinessClassObjet (Clase de negocio)

* Creo mis BSO que daran soporte a cada tabla

# Empezar a crear mis servicios de aplicacion.

* Se define a nivel de capa de interfaz de **Aplicacion** lo que recibira el servicio de aplicacion.

* Se define a nivel de capa de interfaz de **Dominio** lo que recibira el servicio.

* Se implementa el metodo de la interfaz de **Aplicacion** en la clase que implementa la interfaz de **Aplicacion**.
* Se implementa el metodo de la interfaz de **Dominio** en la clase que implementa la interfaz de **Dominio**.

# Empezar a crear mis servicios REST.
* Agrego la inyeccion de dependencias de mis interfaces de la capa **Aplication** y **Dominio**

* Creo mi controlador y agrego mi primer servicio REST.

# Swagger con todos los servicios realizados
![categoryAndInventory](./imgReadme/categoryAndInventory.png)
![ProductAndInvProdAndSubcategory](./imgReadme/ProductAndInvProdAndSubcategory.png)

## Corrida 
![corrida1](./imgReadme/corrida1.png)































