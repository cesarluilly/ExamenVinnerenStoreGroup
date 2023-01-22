# ExamenVinnerenStoreGroup

# Arquitectura NCapas a utilizar

![arquitecturaNCapas](./imgReadme/arquitecturaNCapas.png)

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



## Creamos capa Dominio

## Creamos capa Aplicacion

## Creamos capa de Servicios







































