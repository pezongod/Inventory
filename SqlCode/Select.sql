SELECT * FROM Vara



SELECT Vara.Beskrivning, Subtyp.Namn as 'Sub typ', Typ.Namn as 'Typ'
FROM Vara
join Subtyp on Subtyp.Id = Vara.SubTypId
join Typ on Typ.Id = Subtyp.TypId




SELECT Vara.Id, Vara.Beskrivning, Vara.Pris, Status.Namn, Vara.DatumInköpt, Typ.Id, Typ.Namn, Subtyp.Id, Subtyp.Namn, Vara.BildId
                        from Subtyp
                        join Vara on Subtyp.Id = Vara.SubTypId
                        join Typ on Subtyp.TypId = Typ.Id
                        join Status on Status.Id = Vara.StatusId
                        WHERE Typ.Id = 1