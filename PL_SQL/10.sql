Parameters
===========================================================================================================================================
CREATE OR REPLACE FUNCTION get_tier(p_salary IN NUMBER) RETURN NUMBER IS
...
===============================Parameters mode=============================================================================================
IN/OUT/IN OUT/IN

IN 参数是只读的
Out 参数是可写可读的
Passed by Reference:IN 
Passed by Value:OUT/IN OUT

NOCOPY 类似于引用类型
==============================Formal vs Actual Parameters==================================================================================
FORAML:形参
CREATE OR REPLACE PROCEDURE update_emp(p_dept_name IN VARCHAR2) RETURN NUMBER IS
CREATE OR REPLACE PROCEDURE update_emp(p_dept_name IN employee.emp_dept_id%TYPE) RETURN NUMBER IS
Actual:实参
update_emp('IT')

===========================================================================================================================================
CREATE OR REPLACE
	FUNCTION update_emp(p_emp_id IN NUMBER,
						p_dept_id NUMBER,
						p_location OUT VARCHAR2
	)
	RETURN NUMBER AS
BEGIN
	DBMS_OUTPUT.PUT_LINE('Location initially'||p_location);
	UPDATE employee 
		SET emp_dept_id=p_dept_id
	WHERE emp_id=p_emp_id
	RETURNING emp_loc INTO p_location;
	COMMIT;
	RETURN 1;
EXCEPTION
	WHEN OTHERS THEN
		DBMS_OUTPUT.PUT_LINE(SQLERRM);
		ROLLBACK;
		RETURN 0;
END update_emp;
=======================================================Names/Postion/Mixed Notatons========================================================
Parameters passed by Names/Postion/Mixed
update_emp(p_location=>l_locaton
		   p_emp_id=>l_emp_id,
			p_stats=>l_status,
			p_dept_id=l_dept_id);
====================================================Default values=========================================================================
	CREATE OR REPLACE PROCEDURE update_emp(p_dept_name IN VARCHAR2 DEFAULT 'ABC') RETURN NUMBER IS		



