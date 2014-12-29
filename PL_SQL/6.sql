===EXCEPTIONS===
1.Internally Defined
2.Predefined
3.User Defined

	===========================================================
		DECLARE 
			...
		BEGIN
			...
		EXCEPTION 
			WHEN ZERO DIVIDE THEN
			--Handle EXCEPTION
			WHEN NO_DATA_FOUND THEN
			--DO SOMETHING
			WHEN OTHERS THEN --catch all exception handler
			--HANDLE EXCEPTION
		END;
	===========================================================
	SQLCODE & SQLERRM --the last error code and message
	SQLERRM(-01426)=>ORA-01426:numberic overflow
	SQLERRM(-1430)=>ORA-1430:no data found
	SQLERRM(+100)=>ORA-1430:no data found
	SQLERRM(0)=>ORA-0:normal,succeful completion
	===========================================================
		DECLARE 
			l_num PLS_INTEGER;
			l_sqlcode NUMBER;
			l_sqlerrm VARCHAR2(512);
		BEGIN
			l_num:=2147483648;
		EXCEPTION 
			WHEN OTHERS THEN --catch all exception handler
				l_sqlcode：=SQLCODE;
				l_sqlerrm:=SQLERRM;
				DBMS_OUTPUT.PUT_LINE('SQLCODE:'||l_sqlcode);
				DBMS_OUTPUT.PUT_LINE('SQLERRM:'||l_sqlerrm);
		END;
	==========================PREDEFINED EXCEPTIONS==============
	NO_DATA_FOUND,CASE_NOT_FOUND,TOO_MANY_ROWS,INVLID_CURSOR,CURSOR_ALREADY_OPEN,DUP_VALUE_ON_INDEX,NOT_LOGGED_ON
	
	=============================USER DEFINED EXCEPTIONS=====
	<EXCEPTION_NAME> EXCEPTION;--SQLCODE:1
	PRAGMA EXCEPTION_INIT(<exception_name,-Oracle error number>);
	===================== EXAMPLE 1 =========================
		DECLARE 
			INVLID_QUANTITY EXCEPTION;
			l_order_qty NUMBER:=-2;
		BEGIN
			IF l_order_qty<0 THEN
				RAISE INVLID_QUANTITY;
			END IF;
		EXCEPTION
			WHEN INVLID_QUANTITY THEN
					DBMS_OUTPUT.PUT_LINE('SQLCODE:'||l_sqlcode);
					DBMS_OUTPUT.PUT_LINE('SQLERRM:'||l_sqlerrm);
		END;
	==================PRAGMA map to a internal exception=======
		DECLARE
			l_num PLS_INTEGER;
			too_big EXCEPTION;
			PRAGMA EXCEPTION_INIT(too_big,-1426);
		BEGIN
			--RAISE too_big
			l_num:=2147483648;
			WHEN too_big THEN --catch too_big exception handler
					l_sqlcode：=SQLCODE;
					l_sqlerrm:=SQLERRM;
					DBMS_OUTPUT.PUT_LINE('SQLCODE:'||l_sqlcode);
					DBMS_OUTPUT.PUT_LINE('SQLERRM:'||l_sqlerrm);
		END;
	=====================EXCEPTION SCOPE=======================
	--不同的block里面重新定义的Exception不是同一个Exception,即使名字相同