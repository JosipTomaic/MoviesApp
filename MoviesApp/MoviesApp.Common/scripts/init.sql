delete from CrewMember
delete from CrewMembereMovieCredit
delete from Genre
delete from MovieCredit
delete from MovieGenre
delete from Movie

insert into MovieCredit ("Id", "Name") values (NEWID(), 'Director'), (NEWID(), 'Actor')