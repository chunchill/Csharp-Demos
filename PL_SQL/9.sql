FUNCTIONS
===========================================================================================================================================
Stored Subprogram
Retruns Information
Used in Expressions
=======================================================ORACLE PROVIDED FUNCTIONS===========================================================
Numeric Functions
	ROUND,CEIL,ABS
	SELECT ABS(-123) FROM DUAL;
	
Character Functions
	LPAD,LTRIM,UPPER
	
DateTime Functions

SYSDATE,SYSTIMESTAMP,ADD_MONTHS,
=========================================================Previledges=======================================================================
GRANT CREATE PROCEDURE TO DBDemo
GRANT CREATE PROCEDURE ANY TO DBDemo
GRANT ALTER PROCEDURE ANY TO DBDemo
GRANT EXECUTE ON <schema_name>.<proc_name> TO DBDemo
===================================================Defining Functions======================================================================
CREATE [OR REPLACE] FUNCTION
[schema_name.]<proc_name> RETURN <datatype> IS|AS
<declaration section>

BEGIN
	statements;
RETURN <datatype>;
[EXCEPTION]
END [funtion_name];
===========================================================================================================================================
CREATE OR REPLACE FUNCTION get_emp_count RETURN NUMBER AS
	CURSOR cur_get_dept_id IS|AS
		SELECT dept_id
			FROM departments 
			WHERE dept_name='IT';
	l_dept_id departments.dept_id%TYPE;
	l_count NUMBER:=0;
	BEGIN
		OPEN cur_get_dept_id;
		FETCH cur_get_dept_id into l_dept_id;
		CLOSE cur_get_dept_id;
		SELECT count(*) into l_count FROM employee
			WHERE emp_dept_id=l_dept_id;
			RETURN l_count;
	EXCEPTION
		WITH OTHERS THEN
			DBMS_OUTPUT.PUT_LINE(SQLERRM);
			DBMS_OUPT.PUT_LINE(DBMS_UTILITY.FORMAT_ERROR_BACKTRACE);
			RAISE;
	END get_emp_count;

===========================================================================================================================================
DECLARE
 l_count NUMBER;
BEGIN
	l_count:=get_emp_count;
END;
 get_emp_count