==Conditional execution==
==IF==
	IF <CONDITION> THEN
		STATMENTS;
	END IF;
	
		===========================================================
		DECLARE
			I_SALES_AMT NUMBER:=40000;
			I_NO_OF_ORDERS NUMBER:=120;
			I_COMMISSION NUMBER;
		BEGIN
			IF(I_SALES_AMT>50000 AND I_NO_OF_ORDERS>50)
				OR
			(I_SALES_AMT<50000 AND I_NO_OF_ORDERS>100) THEN
				I_COMMISSION:=10;
			END IF;
		END;
		===========================================================
		IF <CONDITION> THEN
		STATMENTS;
		ELSE
		STATMENTS;
		END IF;
		
		===========================================================
		DECLARE
			I_SALES_AMT NUMBER:=40000;
			I_NO_OF_ORDERS NUMBER:=120;
			I_COMMISSION NUMBER;
		BEGIN
			IF(I_SALES_AMT>50000 AND I_NO_OF_ORDERS>50) THEN
				I_COMMISSION:=10;
				ELSE
				I_COMMISSION:=0;
			END IF;
		END;
	    ===========================================================
		DECLARE
			I_SALES_AMT NUMBER:=40000;
			I_NO_OF_ORDERS NUMBER:=120;
			I_COMMISSION NUMBER;
		BEGIN
			IF NVL(I_SALES_AMT,0)<5000 THEN
				I_COMMISSION:=5;
				ELSE
				I_COMMISSION:=10;
			END IF;
		END;
	    ===========================================================
		IF <CONDITION> THEN
		STATMENTS;
		ELSIF <CONDITION> THEN
		STATMENTS
		ELSE
		STATMENTS;
		END IF;
		===========================================================
		IF <CONDITION> THEN
		STATMENTS;
		ELSIF <CONDITION> THEN
		STATMENTS
		END IF;
		===========================================================
		DECLARE
			I_TICKET_PRIORITY VARCHAR2(8):='MEDIUM';
			I_SUPPORT_TIER NUMBER;
		BEGIN
			IF I_TICKET_PRIORITY='HIGH' THEN
				I_SUPPORT_TIER:=1;
			ELSIF I_TICKET_PRIORITY='MEDIUM' THEN
				I_SUPPORT_TIER:=2;
			ELSIF I_TICKET_PRIORITY='LOW' THEN
				I_SUPPORT_TIER:=3;
			END IF;
			DBMS_OUTPUT.OUTPUT_LINE(I_SUPPORT_TIER);
		END;
		===========================================================
==CASE==
		CASE {variable or expression}
			WHEN VALUE_1 THEN
				STATMENTS_1;
			WHEN VALUE_2 THEN
				STATMENTS_2;
			WHEN VALUE_N THEN 
				STATMENTS_N;
			[ELSE
				STATMENTS_DEFAULT]
		END CASE;
		===========================================================
		DECLARE
			I_TICKET_PRIORITY VARCHAR2(8):='MEDIUM';
			I_SUPPORT_TIER NUMBER;
		BEGIN
			CASE I_TICKET_PRIORITY
				WHEN 'HIGH' THEN
					I_SUPPORT_TIER:=1;
				WHEN 'MEDIUM' THEN
					I_SUPPORT_TIER:=2;
				WHEN 'LOW' THEN
					I_SUPPORT_TIER:=3;
			END CASE;
			DBMS_OUTPUT.OUTPUT_LINE(I_SUPPORT_TIER);
		END;
		===========================================================
		CASE
			WHEN <Condition_1> THEN
				STATMENTS_1;
			WHEN <Condition_2> THEN
				STATMENTS_2;
			WHEN <Condition_N> THEN 
				STATMENTS_N;
			[ELSE
				STATMENTS_DEFAULT]
		END CASE;
		===========================================================
		DECLARE
			I_TICKET_PRIORITY VARCHAR2(8):='MEDIUM';
			I_SUPPORT_TIER NUMBER;
		BEGIN
			CASE 
				WHEN I_TICKET_PRIORITY='HIGH' THEN
					I_SUPPORT_TIER:=1;
				WHEN I_TICKET_PRIORITY='MEDIUM' THEN
					I_SUPPORT_TIER:=2;
				WHEN I_TICKET_PRIORITY='LOW' THEN
					I_SUPPORT_TIER:=3;
			END CASE;
			DBMS_OUTPUT.OUTPUT_LINE(I_SUPPORT_TIER);
		END;
		===========================================================
		CASE {value or expression}
			WHEN <VALUE_1> THEN
				RETURN_VALUE_1
			WHEN <VALUE_2> THEN
				RETURN_VALUE_2
			WHEN <VALUE_3> THEN 
				RETURN_VALUE_3
			[ELSE
				RETURN_VALUE_4]
		END;
		
		CASE {value or expression}
			WHEN <Condition_1> THEN
				RETURN_VALUE_1
			WHEN <Condition_2> THEN
				RETURN_VALUE_2
			WHEN <Condition_3> THEN 
				RETURN_VALUE_3
			[ELSE
				RETURN_VALUE_4]
		END;
		===========================================================
		DECLARE
			I_TICKET_PRIORITY VARCHAR2(8):='MEDIUM';
			I_SUPPORT_TIER NUMBER;
		BEGIN
			I_SUPPORT_TIER:=
			CASE I_TICKET_PRIORITY WHEN 'HIGH' THEN 1 WHEN 'MEDIUM' THEN 2 WHEN 'LOW' THEN 3 ELSE 0 END;
			DBMS_OUTPUT.OUTPUT_LINE(I_SUPPORT_TIER);
		END;
		===========================================================