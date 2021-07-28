# Cosas que se necesitan instalar en vs para que funcione 

Primero se debe correr el [sql script](https://github.com/FedericoCosta2021/MysqlScript-ultima2021.git)

Tambien en vs se necesitan unos packets del NuGet Package Manager:

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

Ahora en el solution explorer dele refresh, si no funciona, abra las referencias de los proyectos y dele refresh Si nada funciona, reinicie vs.

---

### Usuarios y claves
 
Ya hay personas precargadas en la Base de datos, sus usernames son sus cedulas las cuales consisten de solo un numero reperido 8 veces y sus claves son 'claveX' donde x es el numero de cedula que se repite por ejemplo:

```
Alumno: Penelope Cruz
ci: 11111111
clave: clave1

Alumno: Pepe rock
ci: 22222222
clave: clave2
```

este patron se repite para docentes tambien. Por lo tanto: 
- alumnos son las cedulas 1-6 
- docentes 7-8 
- admins 9, clave: adminclave

---

## Otras links:
[trello](https://github.com/FedericoCosta2021/MysqlScript-ultima2021.git)

[miro](https://github.com/FedericoCosta2021/MysqlScript-ultima2021.git)

[github config de servidores](https://github.com/ULTIMA2021/Sistemas-Operativos)
