==PL/SQL Datatypes==

--Scalar datatypes
--Composite datatypes
--Reference datatypes
--other datatypes

Scalar:
	Numeric Datatypes:Number,PLS_INTEGER,BINARY_INTEGER,BINARY_FLOAT,BINARY_DOUBLE
		1E-130: one expotential 130-1E 126
		NUMBER(precision,scale) NUMBER(4,2) 12.34
		NUMBER(5,-2) 12345.678->12300,156.456->200
		
DECLARE 

I_first NUMBER;
I_second NUMBER :=12.12;
I_third NUMBER DEFAULT 2.123;
I_fouth CONSTANT NUMBER DEFAULT 2.123;

END


Subtypes:subset of base type

INTEGER:NUMBER(38,0)
Numeric(P,S)=>NUMBER(P,S)

USER Defined 
	SUBTYPE <name> IS <base_type> [(constraint)][NOT NULL]
	e.g.: SUBTYPE myinterger IS NUMBER(38,0) NOT NULL
	
%TYPE :only the type, not the constraint
	Anchored type, it can be anchored to a previously declared type ,It is also could be achored to table's column
	
	DECLARE 
		I_num NUMBER(5,2) NOT NULL DEFAULT 2.21
		I_num_var_type I_num%TYPE:=1.123;
	BEGIN
		I_num_var_type=3.15;
	END;

PLS_INTEGER/BINARY_INTEGER ,Faster, Range:-2,147,483,648-2,147,483,647

PLS_INTEGER Subtypes: NATURAL,NATURALN,POSTIVE,POSITIVEN,SIGNTYPE(-1,0,1)

BINARY_DOUBLE/BINARY_FLOAT

Characoter Datatypes

	Database Charater Char:CHAR,VARCHAR2,CLOB
	National Charater Database Char:NCHAR,NVARCHAR2,NCLOB
	
DateTime Datatypes

	DATE,11-NOV-2013 14:25:34 ,TO_DATE('10-NOV-2013 15:25:34','DD-MON-RRRR HH24:MI:SS')
		CURRENT_DATE Seesion DATE, SYSDATE
	TIMESTAMP ,CURRENT_TIMESTAMP,SYSTIMESTAMP
		TIMESTAMP WITH TIME ZONE
	INTERVAL
	
		INTERVAL YEAR(3) TO MONTH,INTEGER DAY TO SECOND
		
		DECLARE
		
			I_int INTEGER YEAR(3) TO MONTH;
		BEGIN
			I_int:=INTERVAL '123-2' YEAR TO MONTH;
			I_int:='123-2';
			I_INT:=INTERVAL '123' YEAR;
			I_int:=INTERVAL '2' MONTH;
		END;
	
	
BOOLEAN Datatypes
	Values:TRUE,FALSE,NULL
	
COMPOSITION DATATYPES
	Records,Nested table, Arrays
	Record:Group of items, Not Notation
	Type rec_name IS RECORD(Field Declaration)
	
	
	CREATE TABLE department(
	depet_id NUMBER NOT NULL PRIMARY KEY,
	dept_name Varchar2(60)
	);
	DECLARE
		TYPE em_rec is record(
			dept_id department.depet_id%type,
			location Varchar2(10) Default 'CA'
		);
	I_emprec emp_rec;
	BEGIN
	END;
		

Record Based on 
			TABLE,VIEW,Cursor

	DECLEAR 
		I_dept_rec departments%ROWTYPE;
	BEGIN
		I_dept_rec.dept_id:=10;
		...
	END;
		
		
	We can also nestes a record into another record.
	
	DECLEAR 
		TYPE employe_rec IS RECORD (
			emp_name VARCHAR2(60),
			deptrec departments%ROWTYPE,
			loc VARHCAR2(10) DEAFAULT 'CA'
		);
	BEGIN
	END;
OTHER DATATYPES:CLOB,BLOB,BFILE,Collections(VARRAYS,NESTED TABLES,ASSOCIATEVIE ARRAYS,ROWID/UNROWID)
		
	