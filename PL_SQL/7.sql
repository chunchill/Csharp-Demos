==Debugging==

1.Debugging Options
	DBMS_OUTPUT
	DBMS_UTILITY
	SQL DEVELOPER DEBUGER
	=============DBMS_OUTPUT==================================
	PUT_LINE(msg IN VARCHAR2);
	PUT(msg IN VARCHAR2);--PUT into buffer
	NEW_LINE();
	GET_LINE(line OUT VARCHAR2,status OUT INTEGER);
	GET_LINES(line OUT CHARARR,numberlines OUT INTEGER);
	ENABLE(buffer_size IN INTEGER DEFAULT 20000);
	DISABLE;
	DBMS_OUTPUT.PUT_LINE(to_char(SQLCODE))
	
	===============DBMS_UTILITY=================================
	--FORMATE_ERROR_STACK
	--FORMATE_ERROR_BACKTRACE:(ORA-06512:at line 2)
		DECLARE
			l_num PLS_INTEGER;
		BEGIN
			l_num:=2147483648;
		EXCEPTION
			WHEN OTHERS THEN
				DBMS_OUTPUT.PUT_LINE(DBMS_UTILITY.FORMATE_ERROR_STACK);--GET THE ERROR STACK
		END;
	===========================================================
	--SQL NAVIGATOER TOOL
	GRANT DEBUG CONNECT SESSION TO demoDB;
	GRANT DEBUG ANY PROCEDURE TO demoDB;
	
	
	
