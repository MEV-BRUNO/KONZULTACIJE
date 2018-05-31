
CREATE DATABASE IF NOT EXISTS konzultacije_baza

CREATE TABLE IF NOT EXISTS Studij(
	id_studij INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	naziv VARCHAR(225)
);

CREATE TABLE IF NOT EXISTS Kolegij(
	id_kolegij INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	naziv VARCHAR(225)
);

CREATE TABLE IF NOT EXISTS Profesor(
	id_profesor INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	ime_i_prezime VARCHAR(255),
	email VARCHAR(255),
	lozinka VARCHAR(255),
	aktivacijski_link VARCHAR(225),
	aktivan BOOL
);

CREATE TABLE IF NOT EXISTS Student(
	id_student INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	ime_i_prezime VARCHAR(225),
	id_studij INT,
	FOREIGN KEY(id_studij) REFERENCES Studij(id_studij),
	email VARCHAR(225),
	lozinka VARCHAR(225),
	aktivacijski_link VARCHAR(225),
	aktivan BOOL
);

CREATE TABLE IF NOT EXISTS Upit(
	id_upit INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	id_student INT,
	FOREIGN KEY(id_student) REFERENCES Student(id_student),
	id_profesor INT,
	FOREIGN KEY(id_profesor) REFERENCES Profesor(id_profesor),
	datum DATETIME NOT NULL,
	naslov VARCHAR(225),
	opis VARCHAR(225),
	odgovoren BOOL
);

CREATE TABLE IF NOT EXISTS Termini(
	id_profesor INT,
	FOREIGN KEY(id_profesor) REFERENCES Profesor(id_profesor),
	id_kolegij INT,
	FOREIGN KEY(id_kolegij) REFERENCES Kolegij(id_kolegij),
	dan_tjedan DATETIME NOT NULL,
	vrijeme_od TIME NOT NULL,
	vrijeme_do TIME NOT NULL
);


CREATE TABLE IF NOT EXISTS Kolegij_profesor(
	id_profesor INT,
	FOREIGN KEY(id_profesor) REFERENCES Profesor(id_profesor),
	id_kolegij INT,
	FOREIGN KEY(id_kolegij) REFERENCES Kolegij(id_kolegij)
);



INSERT INTO studij VALUES (NULL, 'Računarstvo');
INSERT INTO studij VALUES (NULL, 'Menadžment turizma i sporta');
INSERT INTO studij VALUES (NULL, 'Održivi razvoj');




/* Popis predmeta za računarstvo*/
INSERT INTO kolegij VALUES (NULL, 'Engleski jezik 1');
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 1');
INSERT INTO kolegij VALUES (NULL, 'Matematika 1');
INSERT INTO kolegij VALUES (NULL, 'Ekonomika i organizacija poslovnih sustava');
INSERT INTO kolegij VALUES (NULL, 'Fizika');
INSERT INTO kolegij VALUES (NULL, 'Osnove elektrotehnike i elektronike');
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 2');
INSERT INTO kolegij VALUES (NULL, 'Primjena računala');
INSERT INTO kolegij VALUES (NULL, 'Engleski jezik 2');
INSERT INTO kolegij VALUES (NULL, 'Matematika 2');
INSERT INTO kolegij VALUES (NULL, 'Programiranje');
INSERT INTO kolegij VALUES (NULL, 'Digitalni elektronički skolopovi');
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 3');
INSERT INTO kolegij VALUES (NULL, 'Vještine komuniciranja');
INSERT INTO kolegij VALUES (NULL, 'Algoritmi i strukture podataka');
INSERT INTO kolegij VALUES (NULL, 'Vjerojatnost i statistika');
INSERT INTO kolegij VALUES (NULL, 'Arhitektura računala');
INSERT INTO kolegij VALUES (NULL, 'Objektno orijentirano programiranje 1');
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 4');
INSERT INTO kolegij VALUES (NULL, 'Programski alati u programiranju');
INSERT INTO kolegij VALUES (NULL, 'Baze podataka 1');
INSERT INTO kolegij VALUES (NULL, 'Računalne mreže');
INSERT INTO kolegij VALUES (NULL, 'Operacijski sustavi');
INSERT INTO kolegij VALUES (NULL, 'Izrada web sadržaja');
INSERT INTO kolegij VALUES (NULL, 'Multimedija');
INSERT INTO kolegij VALUES (NULL, 'Uvod u informacijsku sigurnost');
INSERT INTO kolegij VALUES (NULL, 'Programsko inženjerstvo i informacijski sustavi');
INSERT INTO kolegij VALUES (NULL, 'Objektno orijentirano programiranje 2');
INSERT INTO kolegij VALUES (NULL, 'Seminar A');
INSERT INTO kolegij VALUES (NULL, 'Sigurnost računalnih umreženih sustava');
INSERT INTO kolegij VALUES (NULL, 'Administracija računalnih mreža');
INSERT INTO kolegij VALUES (NULL, 'XML Programiranje');
INSERT INTO kolegij VALUES (NULL, 'PHP Programiranje');
INSERT INTO kolegij VALUES (NULL, 'Baze podataka 2');
INSERT INTO kolegij VALUES (NULL, 'Digitalni marketing i oglašavanje');
INSERT INTO kolegij VALUES (NULL, 'Menadžment');
INSERT INTO kolegij VALUES (NULL, 'Integracija računalnih sustava');
INSERT INTO kolegij VALUES (NULL, 'Razvoj mobilnih aplikacija');
INSERT INTO kolegij VALUES (NULL, 'Razvoj računalnih igara');
INSERT INTO kolegij VALUES (NULL, 'Složeni aplikacijski programi');


/*Popis predmeta za Menadžment turizma i sporta preddiplomski*/
INSERT INTO kolegij VALUES (NULL, 'Ekonomska matematika');
INSERT INTO kolegij VALUES (NULL, 'Osnove ekonomije');
INSERT INTO kolegij VALUES (NULL, 'Osnove trgovačkog prava');
INSERT INTO kolegij VALUES (NULL, 'Poslovni engleski jezik 1');
INSERT INTO kolegij VALUES (NULL, 'Poslovni njemački jezik 1');
INSERT INTO kolegij VALUES (NULL, 'Primjena računala u poslovnoj praksi');

INSERT INTO kolegij VALUES (NULL, 'Mikroekonomija');
INSERT INTO kolegij VALUES (NULL, 'Organizacija');
INSERT INTO kolegij VALUES (NULL, 'Osnove statistike');
INSERT INTO kolegij VALUES (NULL, 'Poduzetništvo');
INSERT INTO kolegij VALUES (NULL, 'Poslovni engleski jezik 2');
INSERT INTO kolegij VALUES (NULL, 'Poslovni njemački jezik 2');

INSERT INTO kolegij VALUES (NULL, 'Makroekonomija');
INSERT INTO kolegij VALUES (NULL, 'Osnove Menadžmenta');
INSERT INTO kolegij VALUES (NULL, 'Osnove računovodstva');
INSERT INTO kolegij VALUES (NULL, 'Porezni sustav');
INSERT INTO kolegij VALUES (NULL, 'Poslovne financije');

INSERT INTO kolegij VALUES (NULL, 'Hotelski Menadžment');
INSERT INTO kolegij VALUES (NULL, 'Operativno planiranje');
INSERT INTO kolegij VALUES (NULL, 'Osnove marketinga');
INSERT INTO kolegij VALUES (NULL, 'Osnove turizma');
INSERT INTO kolegij VALUES (NULL, 'Poslovno pregovaranje i komuniciranje');

INSERT INTO kolegij VALUES (NULL, 'Animacija u turizmu');
INSERT INTO kolegij VALUES (NULL, 'Turistička geografija');
INSERT INTO kolegij VALUES (NULL, 'Ekonomika turizma');
INSERT INTO kolegij VALUES (NULL, 'Pravo u turizmu');
INSERT INTO kolegij VALUES (NULL, 'Marketing u turizmu');
INSERT INTO kolegij VALUES (NULL, 'Sportski marketing');
INSERT INTO kolegij VALUES (NULL, 'Menadžment turizma i sporta');
INSERT INTO kolegij VALUES (NULL, 'Povijest sporta');
INSERT INTO kolegij VALUES (NULL, 'Uvod u sportsko pravo');
INSERT INTO kolegij VALUES (NULL, 'Turizam i kultura');
INSERT INTO kolegij VALUES (NULL, 'Medicina u turizmu i sportu');
INSERT INTO kolegij VALUES (NULL, 'Menadžment poslovne sigurnosti');
INSERT INTO kolegij VALUES (NULL, 'Poslovna etika');
INSERT INTO kolegij VALUES (NULL, 'Digitalni marketing i oglašavanje');
INSERT INTO kolegij VALUES (NULL, 'Turizam i razvoj');
INSERT INTO kolegij VALUES (NULL, 'Istraživanje turističkog tržišta');
INSERT INTO kolegij VALUES (NULL, 'Specifični oblici turizma');
INSERT INTO kolegij VALUES (NULL, 'Menadžment sporta');
INSERT INTO kolegij VALUES (NULL, 'Osnove kineziologije');
INSERT INTO kolegij VALUES (NULL, 'Sustavi natjecanja u sportu');
INSERT INTO kolegij VALUES (NULL, 'Strani jezik - engleski jezik');
INSERT INTO kolegij VALUES (NULL, 'Strani jezik - njemački jezik');
INSERT INTO kolegij VALUES (NULL, 'Informacijska pismenost');
INSERT INTO kolegij VALUES (NULL, 'Marketing turističkih i sportskih događaja');
INSERT INTO kolegij VALUES (NULL, 'Uvod u informacijsku sigurnost');
INSERT INTO kolegij VALUES (NULL, 'Organizacija javnih okupljanja');
INSERT INTO kolegij VALUES (NULL, 'Izrada web sadržaja');
INSERT INTO kolegij VALUES (NULL, 'Osnove prava EU');
INSERT INTO kolegij VALUES (NULL, 'Razvoj inovativnih turističkih proizvoda');






/*Popis predmeta za studij održivi razvoj*/
INSERT INTO kolegij VALUES (NULL, 'Matematika 1');
INSERT INTO kolegij VALUES (NULL, 'Osnove energetike');
INSERT INTO kolegij VALUES (NULL, 'Osnove računarstva');
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 1 - engleski jezik');
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 1 -  njemački jezik');
INSERT INTO kolegij VALUES (NULL, 'Tehničko crtanje');
INSERT INTO kolegij VALUES (NULL, 'Tehnologija materijalnih resursa');

INSERT INTO kolegij VALUES (NULL, 'Ekonomika i organizacija poslovanja');
INSERT INTO kolegij VALUES (NULL, 'Fizika');
INSERT INTO kolegij VALUES (NULL, 'Komunikologija');
INSERT INTO kolegij VALUES (NULL, 'Konstrukcijsko crtanje');
INSERT INTO kolegij VALUES (NULL, 'Matematika 2');
INSERT INTO kolegij VALUES (NULL, 'Primjenjena statistika');
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 2 - engleksi jezik');
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 2 - njemački jezik');

INSERT INTO kolegij VALUES (NULL, 'Elektrotehnika');
INSERT INTO kolegij VALUES (NULL, 'Mehanika fluida');
INSERT INTO kolegij VALUES (NULL, 'Tehnologija 1');
INSERT INTO kolegij VALUES (NULL, 'Upravljanje kvalitetom');
INSERT INTO kolegij VALUES (NULL, 'Termodinamika');
INSERT INTO kolegij VALUES (NULL, 'Tehnološki software');

INSERT INTO kolegij VALUES (NULL, 'Tehnologija 2');
INSERT INTO kolegij VALUES (NULL, 'Održavanje');
INSERT INTO kolegij VALUES (NULL, 'Elektronički sklopovi');
INSERT INTO kolegij VALUES (NULL, 'Osnove energetike i ekologije');
INSERT INTO kolegij VALUES (NULL, 'Energetske pretvorbe');
INSERT INTO kolegij VALUES (NULL, 'Osnove automatike');

INSERT INTO kolegij VALUES (NULL, 'Grijanje i klimatizacija');
INSERT INTO kolegij VALUES (NULL, 'Rashladna tehnika');
INSERT INTO kolegij VALUES (NULL, 'Vodovodne i plinske instalacije');
INSERT INTO kolegij VALUES (NULL, 'Pumpe, ventilatori i kompresori');
INSERT INTO kolegij VALUES (NULL, 'Mjerenje u termotehnici');
INSERT INTO kolegij VALUES (NULL, 'Ekološka održivost');
INSERT INTO kolegij VALUES (NULL, 'Upravljački software');
INSERT INTO kolegij VALUES (NULL, 'Oblikovanje pomoću računala');
INSERT INTO kolegij VALUES (NULL, 'Tehnička dokumentacija i propisi');
INSERT INTO kolegij VALUES (NULL, 'Ekološka zaštita');
INSERT INTO kolegij VALUES (NULL, 'Upravljanje termotehničkim sustavom');
INSERT INTO kolegij VALUES (NULL, 'Toplinske mreže');
INSERT INTO kolegij VALUES (NULL, 'Održivost energije i samoodrživost');
INSERT INTO kolegij VALUES (NULL, 'Komunalno projektiranje');
INSERT INTO kolegij VALUES (NULL, 'Industrijska sociologija');
INSERT INTO kolegij VALUES (NULL, 'Statika i otpornost konstrukcije');
INSERT INTO kolegij VALUES (NULL, 'Arhitektonske konstrukcije i projektiranje');
INSERT INTO kolegij VALUES (NULL, 'Tehnologija građenja 1');
INSERT INTO kolegij VALUES (NULL, 'Ogranizacija građenja 1');
INSERT INTO kolegij VALUES (NULL, 'Mehanika graditeljstva');
INSERT INTO kolegij VALUES (NULL, 'Građevinske konstrukciej i projektiranje');
INSERT INTO kolegij VALUES (NULL, 'Dimenzioniranje jednostavnih konstrukcija');
INSERT INTO kolegij VALUES (NULL, 'Dimenzioniranje složenih konstrukcija');
INSERT INTO kolegij VALUES (NULL, 'Urbanističko planiranje i projektiranje');
INSERT INTO kolegij VALUES (NULL, 'Organizacija građenja 2');
INSERT INTO kolegij VALUES (NULL, 'Tehnologija građenja 2');
INSERT INTO kolegij VALUES (NULL, 'Održivost arhitekture');
INSERT INTO kolegij VALUES (NULL, 'Ekologija');

