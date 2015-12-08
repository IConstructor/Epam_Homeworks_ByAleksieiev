USE OnlineGameStoreDatabase;

CREATE TABLE COMMENT
(
CommentPK int PRIMARY KEY IDENTITY,
Name nvarchar(50),
Body nvarchar(max),
ParentComment int FOREIGN KEY REFERENCES COMMENT(CommentPK),
GameFK int FOREIGN KEY REFERENCES GAME(GamePK) ON DELETE CASCADE,
CONSTRAINT ParentConstraint CHECK(ParentComment != CommentPK)
)

CREATE TABLE GENRE
(
GenrePK int PRIMARY KEY IDENTITY,
Name nvarchar(50) UNIQUE,
ParentGenre int FOREIGN KEY REFERENCES GENRE(GenrePK),
CONSTRAINT ParentGenreConstraint CHECK(ParentGenre != GenrePK)
)

CREATE TABLE GENREGAME
(
GenreFK int FOREIGN KEY REFERENCES GENRE(GenrePK),
GameFK int FOREIGN KEY REFERENCES GAME(GamePK) ON DELETE CASCADE,
CONSTRAINT GenreGamePK PRIMARY KEY(GenreFK,GameFK)
)

CREATE TABLE PLATFORMTYPE
(
PlatformtypePK int PRIMARY KEY IDENTITY,
Name nvarchar(50) UNIQUE
)

CREATE TABLE PLATFORMTYPESGAMES
(
PlatformtypeFK int FOREIGN KEY REFERENCES PLATFORMTYPE(PlatformtypePK),
GameFK int FOREIGN KEY REFERENCES GAME(GamePK) ON DELETE CASCADE,
CONSTRAINT PlatGamePK PRIMARY KEY(PlatformtypeFK, GameFK)
)


CREATE TABLE GAME               
(                                    
	GamePK int PRIMARY KEY IDENTITY,  
	Name nvarchar(100), 
	[Description] nvarchar(max)
);
GO

DROP TABLE COMMENT
DROP TABLE PLATFORMTYPESGAMES
DROP TABLE PLATFORMTYPE
DROP TABLE GENREGAME
DROP TABLE GAME
DROP TABLE GENRE

