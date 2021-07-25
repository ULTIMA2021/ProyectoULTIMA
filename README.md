# Cosas que se necesitan instalar en vs para que funcione 

Primero se debe correr el [sql script](https://github.com/FedericoCosta2021/MysqlScript-ultima2021.git)

Luego se necesitan unos packets del NuGet Package Manager:

` MySql.Data by oracle`

` Microsoft.VisualBasic.PowerPacks.Vs`


- abri el proyecto

- tools `->` NuGet package manager `->` Manage NuGet Packages for solution 

- capaz que le aparece un msg para descargar los paquetes

- si no en la nueva ventana cambiese a browse y busque
` MySql.Data by oracle`
  - en donde le pide indicar las referencias ponga CapaDeDatos y CapaLogica. Dale instalar

- Vaya devuelta a browse y ahora busque:
` Microsoft.VisualBasic.PowerPacks.Vs`

- en donde le pide indicar las referencias ponga AppAlumno,AppDocente,AppAdmin y Login. Dale instalar

Ahora en el solution explorer dele refresh, si no funciona, abra las referencias de los proyectos y dele refresh Si nada funciona, reinicie vs
