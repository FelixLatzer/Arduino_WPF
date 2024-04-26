# FSST Projekt: Anforderungen

Anbei findet ihr die Anforderungen an das Projekt. Die genaue Timeline werden wir noch klären.

## Organisatorisches

* 1er Teams
* Arbeit teils im Unterricht, teils zuhause
* **Deadline:** 21.06.2024 (Endpräsentation + Projektabgabe)

## Technischer Inhalt

Verpflichtend:

* OOP (Verwendung von Klassen)
* Collections (Listen, ...)
* Graphische Darstellung von Objekten
* Serialisierung (Speichern/Laden von Daten)
* Unterformulare (PopUp Fenster, Inhalte die sich ändern, etc.)

Optional:

* Anwendung hat eine Menüzeile
* Erstellen von Animationen (z.B.: bei Spielen)
* Möglichkeit für Ausdrucke aus dem Programm
* Andbindung einer API
* Verwendung von externen Bibiliotheken (NuGet Packages)
* uvm.

## Benotung

* Erfüllung der Grundanforderungen => max. 3er möglich
* Einflussfaktoren für bessere Noten
  * Komplexität des Projekts
  * Umsetzung des Projekts (Feinschliff, keine Bugs, ist die Anwendung intuitiv)
  * Wie gut wurde die Dokumentation umgesetzt
  * Gesamteindruck

## Ablauf

* Projektidee ausarbeiten
* Planungsphase
* Umsetzungsphase
* Präsentation und Abgabe

::: hint
Wenn wir in der Unterrichtszeit an den Projekten arbeiten, könnt ihr entsprechend Fragen stellen.
:::

::: hint
Wenn ihr Grafiken, Sounds, etc. verwendet, achtet darauf, dass sie frei verwendbar sind (z.B.: Creative Commons Lizenz). In der Dokumentation sollen auch die Quellen (Referenz + Lizenz) genannt werden. Oder erstellt die Grafiken eigenständig.
:::

### Projektidee

Jedes Team überlegt sich eine Projektidee. Dabei sollen bereits folgende Überlegungen in einem Dokument zusammengefasst werden.

* Wie werden die Mindestanforderungen umgesetzt?
* Welche Features sind ein muss
* Welche Features sind Erweiterungen (nice-to-have), wenn genügend Zeit bleibt
* Wie möchten wir das Ganze grob umsetzen

Abgabeform ist hierbei ein kurzes Dokument. Nach der Freigabe könnt ihr mit der nächsten Phase starten.

### Planungsphase

Bitte beginnt bei der Umsetzung zuerst mit einer kurzen Planungsphase.
Plant hier folgende Dinge (beispielsweise als Skizze am Blatt):

* Aufbau der GUI (Skizzen):
  * Welche Fenster wird es geben?
  * Wie sehen diese grob aus?
  * Wie ist die Benutzernavigation geplant?
* Aufbau des Programms
  * Welche Klassen wird es geben. Klassendiagramm ist hierbei verpflichtend!
  * Wie arbeiten die Klassen miteinander
  * Genauere Planung der Klassen an sich: Properties, Methoden, Konstruktoren
* Zeitlichen Ablauf planen
  * Tabellarische Form: Datum, was wird gemacht, von wem wird es gemacht, Zeitschätzung

### Umsetzungsphase

In dieser Zeit arbeitet ihr an euren Projekten. Erweitert regelmäßig die Dokumentation und führt ein Projekttagebuch.

Mögliche Stolpersteine und Lösungen dazu sollen dokumentiert werden.

### Präsentation/Abgabe

Den genauen Ablauf der Präsentationen werden wir kurz vor Ende besprechen. Die Abgabeform ist wie folgt.

* Dokumentation als pdf
  * Projekttagebuch: Wann hast du an was gearbeitet?
  * Projektplanung (Lastenheft)
  * Umsetzungsdetails (Pflichtenheft)
    * Welche Softwarevoraussetzungen werden benötigt (mit Versionen)
    * Funktionsblöcke bzw. Architektur (grob)
    * Beschreibung der Umsetzung
    * Mögliche Probleme und ihre Lösung
  * Quellen für vewendete Bilder, oder andere Medien
* Projektordner als *.zip-Archiv

Ordnerstruktur der Abgabe

* `[GXX]_[Projektname]_[Name1]_[Name2]`
  * `doc` ... Dokumentation (pdf, md)
  * `src` ... Komplettes VisualStudio Projekt
  * `bin` ... Kompiliertes Programm (*.exe) mit allen benötigten Abhängigkeiten (Bilder, andere `*.dlls`)
