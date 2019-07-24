SELECT * FROM Vara



SELECT Vara.Beskrivning, Subtyp.Namn as 'Sub typ', Typ.Namn as 'Typ'
FROM Vara
join Subtyp on Subtyp.Id = Vara.SubTypId
join Typ on Typ.Id = Subtyp.TypId
