====================================================Local Subprograms======================================================================
Declare Section 
Scope From Point of Decleartion to End of the Block

============================================================================================================================================================
CREATE OR REPLACE
	FUNCTION update_emp(p_emp_id IN NUMBER,
						p_dept_id NUMBER,
						p_location OUT VARCHAR2
	)
	RETURN NUMBER AS
	--Local Subprograms
	PROCEDURE display_message(p_location IN VARCHAR2) IS
	BEGIN
		DBMS_OUTPUT.PUT_LINE(p_location);
	END;
	
	
BEGIN
    display_message('Location initially'||p_location);
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