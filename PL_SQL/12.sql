Package Specification/Package Body
========================================================================================================================================
Package Specification
No implementations
Can Exist dependently
Public APIs,Variables&Object

Package Body
implementations
Can not Exist dependently
Private APIs,Variables&Object

===========================================Package Specification========================================================================
Create [OR REPLACE] Package
[schema_name.]<package_name> IS|AS

declarations;
END[<package_name>];

===========================================Package Specification Example=================================================================
Create [OR REPLACE] Package
hr_mgmt IS

	g_active_status CONSTANT VARCHAR2(1):='A';
	g_inactive_status CONSTANT VARCHAR2(1):='I';
	g_bounus_pct NUMBER;

	dept_not_found_ex EXCEPTION;

	TYPE g_rec IS RECORD(p_profit NUMBER,p_dept_name departments.dept_name%TYPE);

	CURSOR gcur_get_deptid(p_dept_name VARCHAR2) IS
		SELECT dept_id FROM departments WHERE dept_name=p_dept_name；
	FUNCTION cal_bonus(p_profit NUMBER,p_dept_id NUMBER) RETURN NUMBER;
	PROCEDURE update_empt(p_emp_id NUMBER,p_dept_name VARCHAR2);
END hr_mgmt;
===========================================Package Specification complie================================================================
ALTER PACKAGE hr_mgmt COMPILE SPECIFICATION;

===========================================Package Specification executing==============================================================
Cannot Excute without body

DECLARE 
	l_emp_id NUMBER:=50;
	l_dept_name VARCHAR2:='IT';
BEGIN
	demo.hr_mgmt.update_empt(l_emp_id,l_dept_name);
END;

===========================================Package Specification DROP       ============================================================
DROP PACKAGE package_name

===========================================Package Body Specification===================================================================
CREATE [OR REPLACE] PACKAGE Body
[schema_name.]<package_name> IS|AS

declarations;
[BEGIN
EXCEPTION]
END[<package_name>];
===========================================Package body Example         =================================================================
Create [OR REPLACE] Package
hr_mgmt IS
 CURSOR cur_get_sal(p_dept_id NUMBER) IS
	SELECT SUM(emp_sal)
		FROM employee
		WHERE emp_dept_id=p_dept_id
		AND emp_status=g_active_status;
  PROCEDURE cal_bonus(p_profit NUMBER) IS
  ...
  END cal_bonus;
  
  FUNCTION update_empt ...
  END update_empt;
END hr_mgmt;

ALTER PACKAGE hr_mgmt COMPILE body;