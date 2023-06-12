# Laroni-Travel

<h2>Link naar github en branch main</h2>
<p>https://github.com/Laurens8/Laroni-Travel branch main</p>
<br>
<br>
<h2>Uitleg rond applicatie</h2>
<p>De applicatie bevat 6 Views. De eerste View bij het opstarten van de applicatie is de InlogView. Je dient dus hier aan te melden met een emailadres en gehasht wachtwoord.</p> 
<p>Standaard login is <b>emma@email.com</b> en wachtwoord is <b>azertyqwerty</b>.</p>
<p>Moest het wachtwoord niet werken dan kan er een nieuw wachtwoord aangemaakt worden via de WachtwoordVergetenView. Je geeft dan het emailadres in en dan het nieuwe wachtwoord</p>
<p>Eenmaal het aanloggen is gelukt kom je op de HomeView of het dashboard terecht. Dit hebben we van wat info voorzien van hoeveel deelnemers ingeschreven zijn, hoeveel reizen er al zijn, wanneer er opleidingen plaatsvinden en een kalender wat de datum of datumrange zou moeten weergeven van de groepsreizen</p>
<p>Als je in de navbar op PersoonView drukt kan je een lijst opvragen in een datagrid met alle ingeschreven personen aan de hand van de voornaam of gedeelte van de voornaam. Een geselecteerde deelnemer kan men dan ook aanpassen of verwijderen. Of men kan ook een nieuwe deelnemer aanmaken. Elke deelnemer heeft op deze pagina ook medische gegevens, ook aan de medische records zijn CRUD operaties toegevoegd. De View toont ook foutmeldingen bij bv het aanmaken van een nieuwe deelnemer dat alle velden ingevuld dienen te zijn. De buttons reageren naargelang er een deelnemer geselecteerd is of niet, of/en als er een medisch record geselecteerd is of niet</p>
<p>Als men in de navbar op ReizenView drukt dan kan je daar opnieuw een lijst opvragen van de groepsreizen maar deze keer aan de hand van een ID. Ok hier zijn CRUD operaties aan toegevoegd bij de in te vullen velden. Onderaan het gedeelte van de lijst met groepsreizen kan je ook de deelnemers zien die al deelnemen aan de reis. Deze kan je eveneens uit de lijst verwijderen en men kan aanpassen of de deelnemer betaald heeft of niet. Daaronder heb je dan weer een zoekoptie voor een deelnemer te zoeken in de lijst met alle deelnemers en deze kan je dan gaan toevoegen aan de reis rekening houdend dat de leeftijd overeen komt met de leeftijdscategorie. Opnieuw zijn de buttons enabled of disabled naargelang het selecteren van een reis. Foutmeldingen worden getoond als bepaalde velden leeg blijven</p>
<p>De laatste View in de navbar is de OpleidingView die eigenlijk net hetzelfde is opgebouwd als de ReizenView. Je kan dus alweer bestaande opleidingen gaan raadplegen, aanpassen of verwijderen en je kan nieuwe opleidingen aanmaken, je kan deelnemers aan de opleiding raadplegen en verwijderen en je kan deelnemers toevoegen aan de opleiding. Ook hier dus weer reageren de buttons op het selecteren of niet selecteren van een opleiding en ook hier zijn weer foutmeldingen in een label toegevoegd wanneer een veld niet ingevuld is</p>
<p>Laatste button in de navbar is de uitlog button, als je daarop drukt ga je terug naar InlogView</p>
<br>
<br>
<h2>Opzoekingswerk</h2>
<ul>
<li>Er is vooral veel opzoekingwerk gebeurd naar material design voor de Views zo te krijgen als dat ze nu zijn. Hoe je bv een gradient erin krijgt. Hoe je een textbox rond krijgt met material design.</li>
<li>Er is opzoekingswerk gebeurd rond het hashen van een wachtwoord met salt</li>
<li>Het gebruik van "not mapped" in de models hebben we verder opgezocht</li>
<li>Hoe moet je een datum binden aan een datepicker is opgezocht geweest</li>
</ul>
