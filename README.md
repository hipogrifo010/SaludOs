# SaludOs
Api de Listados de precios Farmacéuticos.


##**Links**
Aqui se recopilan endpoints y links del Api con dominio en Azure.
https://ubaldoramirez.azurewebsites.net/swagger/index.html

## **Especificación de la Arquitectura**
Se utilizaron los principios Solid, se intento crear la aplicacion lo mas limpio posible.

### **Capa Controller**
Será el punto de entrada a la API. En los controladores se trato de colocar la menor logica posible

### **Capa DataAccess**
Es donde se define DbContext y se crean los seeds correspondientes para popular las entidades.

### **Capa Entities**
En este nivel de la arquitectura defino todas las entidades de la base de datos, para la base de datos relacional.

### **Capa Repositories**
esta capa se encarga de realizar el repositorio genérico y la unidad de trabajo

### **Capa Core**
Es nuestra capa principal, en ella encontramos varios subniveles

*	Helper:Defino logica variada para los servicios. Por ejemplo, algún método para encriptar/desencriptar contraseñas
*	Interfaces: se definen las interfaces de los servicios.
*	Mapper: En esta carpeta irán las clases de mapeo para vincular entidad-dto o dto-entidad
*	Models: en esta se definen los modelos para el desarrollo. Dentro de esta carpeta encontramos DTO.
*	Services: Se incluirán todos los servicios solicitados por el proyecto.

## **Especificación de GIT**

* se incluyen por ramas independientes entre si las features.
* El título del pull request Contiene la historia relacionada.
* Los commits llevan la historia relacionada o una breve descripcion.
* El pull request solo contiene los cambios de las features incluidas o quitadas.


