# LinaProjektet



### Intro 
Varje år driver XXX ett tjugotal olika projekt. Dessvärre finns det i nuläget inget bra system för översyn av dessa projekt eller för att hantera information om projekten. För att åtgärda detta problem har ett projekt startats. Projektgruppen, bestående av Albin Bäckström, XXX och XXX, ska utreda och utveckla ett framtidssäkert IT-baserat system där användare kan läsa, lägga till och ändra information om olika projekt. XXX på XXX är kontaktperson/projektägare.

### Syfter och mål
Syftet med projektet är att underlätta för dels projektdeltagare att mata in uppgifter om sina projekt i systemet och dels för den som vill ta fram uppgifter om vilka projekt som genomförs för tillfället och de projekt som genomförts tidigare.  

Målet med projektet är att skapa en plattform där all information om aktuella projekt samlas. Plattformen ska ha två nivåer av användarrättigheter. I den första nivån ska användare först kunna registrera ett konto och sedan använda det kontot för att mata in uppgifter om sitt projekt. Användare ska sedan även kunna ändra uppgifterna. I den andra nivån ska det räcka med samma inloggningsuppgifter för alla användare. Här ska de till att börja med få upp information om alla projekten som finns i databasen. Senare, i mån av tid, ska användare även kunna söka och sortera bland uppgifterna.


### Teknisk specifikation
Utvecklingen i projektet kommer ske i .NET då det är denna teknik gruppen anser sig kunna bäst. .NET-ramverket är Microsofts utvecklingsplattform.  

Användargränssnittet kommer programmeras i HTML, CSS, jQuery som är ett JavaScript-bibliotek och C#, ett objektorienterat högnivåspråk som är en del av .NET-plattformen. Gränssnittet kommer byggas på arkitekturmönstret MVC som står för Model View Controller. Genom att använda MCV separeras datalagret (Model) från presentationslagret (View) genom att använda en mellanliggande komponent (Controller). Utvecklingen av användargränssnittet kommer dessutom använda Bootstrap, som är ett annat ramverk som används för att styla webbsidor.    

Utvecklingen kommer ske i Microsoft Visual Studio, Microsofts programutvecklingsmiljö och databasen och webbgränssnittet kommer till början att finnas på Microsofts molntjänst Azure för att sedan tas över av projektägaren.
