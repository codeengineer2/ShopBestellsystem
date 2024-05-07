| Warenkorb        |
|------------------|
| - selectedproducts: <List>   |
| + deliverycost: <double>   |
| + <<get, set>> Gespreis: <double>   |
| + <<get, set>> Lieferadresse: <string>   |
| + <<get, set>> Strasse: <string>   |
| + <<get, set>> Vorname: <string>   |
| + <<get, set>> Nachname: <string>   |
| + <<get, set>> Stadt: <string>   |
| + <<get, set>> PLZ: <int>   |
| + <<get, set>> Land: <string>   |
|---------------------------------|
| + Warenkorb(selectedproducts: int, deliverycost: double, gespreis: double, lieferadresse: string, strasse: string, vorname: string, nachname: string, stadt: string, plz: int, land: string )   |
|---------------------------------|
| + Gespreisberechnen(): double   |
| + Serializetotxt(): string   |
| + txttopdf(): void   |
| + Bestellnummer(): int   |


