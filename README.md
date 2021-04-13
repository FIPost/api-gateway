![ipost-logo](https://github.com/FIPost/docs/blob/master/assets/logo-name.png?raw=true)
# api gateway
<h3 align="center">
  <a href="https://github.com/FIPost/docs">Documentation</a>
</h3>

API Gateway for communication between the [frontend]() and [backend](). Abstracts calls into user-friendly endpoints and adds a secure entrypoint layer on top of the individual microservices.

# IPost - Fontys Interne Post
Deze opdracht beoogt het interne post-systeem van de hele Fontys te moderniseren. Op dit moment wordt dit veelal handmatig gedaan. Het doel is dit te verplaatsen naar een systeem dat vergelijkbare functies heeft als een systeem van PostNL. Mogelijkheden die het systeem zou kunnen hebben is dat het op elk moment mogelijk moet zijn te zien wat de status is van een intern stuk post en waar het zich bevindt in de organisatie.
Let hierbij op dat deze opdracht zich niet alleen strekt tot de FHICT, maar de gehele organisatie met meer dan 4300 werknemers en 44.000 studenten.
Dit project maakt deel uit van een pilot en moet op de lange termijn worden ontwikkeld. Dit betekent dat de projectontwikkeling kan worden doorgezet op de langere termijn. De overdraagbaarheid van dit project is een must.

## Wat is dit?
API Gateway voor de communicatie tussen frontend en backend. Zorgt voor web friendly endpoints, een secure entrypoint laag boven de microservices.

## Gerelateerde projecten
- [ipost-docs](https://github.com/FIPost/docs) - Docs over het algehele project
- [ipost-locatieservice](https://github.com/FIPost/locatieservice) - Fontys afhaalpunten voor post.
- [ipost-pakketservice](https://github.com/FIPost/pakketservice) - Pakketinformatie.
- [ipost-ui](https://github.com/FIPost/ui) - Front-end voor het logistieke proces.
- [ipost-track-and-trace-ui](https://github.com/FIPost/track-and-trace-ui) - Front-end voor Track & Trace ontvanger.

## Vereisten

## Getting started

### Run with Docker
```zsh
docker-compose build
docker-compose up
```

#### Note
Make sure that you are in the directory of `docker-compose.yml` when running these commands.

## Bijdragen?
Op dit moment wordt dit project onwikkeld door G4-IPost groep. Mocht je interesse hebben om mee te helpen kun je dit laten weten aan een van de ontwikkelaars.

| Naam | Email |
| ------ | ------ |
| Aron Heesakkers | 418126@student.fontys.nl|
| Jaap van der Meer | 405273@student.fontys.nl |
| Sverre van Gompel |  |
| Sjors Scholten | 361483@student.fontys.nl |
| Kevin Wieling | |
| Robin Witte | 399366@student.fontys.nl |

## Stakeholders

| Naam | Functie |
| ------ | ------ |
| Jacques De Roij | Product Owner en contactpersoon tussen het softwareteam en de eindgebruikers. |
| Patrick de Beer | Coördinator van de softwarestroming van FHICT. Is verantwoordelijk voor langlopende projecten binnen Fontys. |
| Simon Bergmans S.P.C.G. | Postverwerker en eindgebruiker van het systeem. Simon is coördinator van Fontys Tilburg. |
| Levent Önder | Postverwerker en eindgebruiker van het systeem. Levent is verantwoordelijk voor P1 gebouw (7 instituten met meer dan 5000 personen). |

## License
- [licence](https://github.com/FIPost/api-gateway/blob/add-license-1/LICENSE) - Licence File

## FAQ
