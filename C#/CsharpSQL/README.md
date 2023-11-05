Leírás

C#-os konzolos alkalmazás. Felhasználóval való párbeszéden keresztül hajt végre SQL utasításokat SQLite adatbázison. Sok helyen nem felhasználóbarát, 
összeomlik a program, ha rosszul írjuk be az utasításokat. **CREATE TABLE, INSERT INTO, SELECT, DELETE FROM, DROP TABLE parancsok működnek.** Az UPDATE 
parancs lenne a következő. Ha sok rekordot ír ki, és beírod a "watch" kulcsszót, a pageUp gombbal megkönnyítheted a böngészést (a pageDown nem működik). 
A "clear" kulcsszó ugyanaz, mint egy parancssorban.

---

Lépések

0: Visual Studio -> Új projekt -> C# Konzol (.NET Framework) -> 4.7.2-es verzió, név (pl. CsharpSQL)

1:  Program.cs tartalmának bemásolása

2: Solution Explorer -> "CsharpSQL" jobb klikk -> Manage NuGet packages

3: (Package source: nuget.org) klikk Browse -> Keresősáv: System.Data.Sqlite -> Install

4: Start gomb / Build-elés

5: "Create table" kulcsszó, hogy legyen hova adatokat feltölteni, kiolvasni stb.
