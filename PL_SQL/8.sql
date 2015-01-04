Procedures
==========================================================================================================================================
Procedure:
Named Program Units
Peform Unit of Work
Dose not Return Anything

============Setup=========================================================================================================================
CREATE TABLE departments(
	depet_id NUMBER NOT NULL PRIMARY KEY,
	dept_name Varchar2(60)
	);
	
	CREATE TABLE employee(
	emp_id NUMBER NOT NULL PRIMARY KEY,
	emp_name Varchar2(60),
	emp_dept_id NUMBER,
	emp_loc Varchar2(60),
	emp_sal NUMBER,
	emp_status Varchar2(1),
	CONSTRAINT emp_dept_fk FOREIGN KEY(emp_dept_id) REFERENCES departments(emp_dept_id));
===========================================================================================================================================
GRANT CREATE PROCEDURE TO DBDemo
GRANT CREATE PROCEDURE ANY TO DBDemo
GRANT ALTER PROCEDURE ANY TO DBDemo
GRANT EXECUTE ON <schema_name>.<proc_name> TO DBDemo
===========================================================================================================================================
CREATE [OR REPLACE] PROCEDURE
[schema_name.]<proc_name> IS|AS
<declaration section>

BEGIN
	statements;
[EXCEPTION]
END [proc_name];
===========================================================================================================================================
CREATE OR REPLACE PROCEDURE update_dept AS
	l_emp_id employee.emp_id%TYPE:=10;
BEGIN
	UPDATE employee
		SET emp_dpt_id=2
	WHERE emp_id=l_emp_id;
	COMMIT;
EXCEPTION
	WHEN OTHERS THEN
		DBMS_OUTPUT.PUT_LINE(SQLERRM)
		ROLLBACK;
		RAISE;
END update_dept;
===========================================================================================================================================
PL/SQL Optimization Level
0,1,2,3

ALTER SESSION SET PLSQL_OPTIMIZE_LEVEL=2;

SELECT PLSQL_OPTIMIZE_LEVEL,PLSQL_CODE_TYPE FROM ALL_PLSQL_OBJECT_SETTINGS WHERE NAME='update_dept'
===========================================================================================================================================
/:Compile procedure
ALTER PROCEDURE update_dept COMPILE DEBUG;

Setting Warning Levels:
	ALTER SESSION SET PL_SQLWARNINGS='ENABLE:ALL';
	ALTER SESSION SET PL_SQLWARNINGS='ENABLE:PERFORMANCE','ENABLE:SERVER';
	
SHOW ERRORS;
DBMS_WARNING
call dbms_warning_setting_cat('INFORMATIONAL','DISABLE','SESSION');
===========================================================================================================================================
CALL/EXEC[UTE]/DROP <procedure_name>
CALL update_dept();
EXEC update_dept;
EXECUTE update_dept;
BEGIN
	update_dept;
END;
===========================================================================================================================================
USE "return" keyword to exit the Procedure
===========================================================================================================================================
	