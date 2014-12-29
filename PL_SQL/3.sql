==Loops==

==Simple Loop==

	Loop Statement END LOOP;
	IF Statement THEN END IF;
	DECLARE 
		I_COUNTER NUMBER:=0;
		I_SUM NUMBER:=0;
	BEGIN
		Loop
			I_SUM:=I_SUM+I_COUNTER
			I_COUNTER:=I_COUNTER+1;
			EXIT WHEN I_COUNTER>3;
		End Loop;
	END;
	
	
	DECLARE 
		I_COUNTER NUMBER:=0;
		I_SUM NUMBER:=0;
	BEGIN
		Loop
			I_SUM:=I_SUM+I_COUNTER
			I_COUNTER:=I_COUNTER+1;
			IF I_COUNTER>3 THEN
			  GOTO out_of_scope
			END IF
		End Loop;
		<<out_of_scope>>
		null;
	END;
	
	
==For Loops==
	FOR LOOP_COUNTER IN [REVERSE] LOWER_BOUND..UPPER_BOUND LOOP
	 group_of_statments
	End LOOP[LABLE]
	Continue Statment 和我们理解的For循环一致,终止当前的循环，执行下一次循环；
	===========================================================
	CREATE TABLE DEPARTMENTS
	(dept_id NUMBER NOT NULL PRIMARY KEY,
	 dept_name VARCHAR2(60));
	)
	
	INSERT INTO DEPARTMENTS(dept_id,dept_name) values(1,'Sales');
	INSERT INTO DEPARTMENTS(dept_id,dept_name) values(1,'IT');
	
	DECLARE
	 l_dept_count NUMBER;
	BEGIN
		SELECT COUNT(*)
			INTO l_dept_count
			FROM DEPARTMENTS;
		FOR l_counter in 1..l_dept_count LOOP
			DBMS.OUTUPUT.PUT_LINE(l_counter);
		END LOOP
	END;
	===========================================================
	Loop Nesting
	Exit LABLE NAME
	Continue LABLE NAME WHEN conditions;
	BEGIN
	<<myloop>>
		FOR I_COUNTER in 1..3 LOOP
			DBMS_OUTPUT.PUT_LINE(I_COUNTER);
		End Loop myloop;
	END;
	===========================================================
	
==While Loops==
	Explicit EXIT
		EXIT WHEN
		GO TO
		RETURN
	===========================================================
	WHILE <condition> LOOP
		group_of_statment;
	END LOOP;
	
	DECLARE
		I_CHECK INTEGER:=1;
	BEGIN
		WHILE I_CHECK<5 LOOP
			I_CHECK:=DBMS_RANDOM.VALUE(1,10);
			DBMS_OUTPUT.PUT_LINE(I_CHECK)
		END LOOP;
	END;
	===========================================================

==最好避免使用GOTO语句==
GOTO 语句的限制：
	1.GOTO 不能GOTO到if 语句之中的Lable
	2.不能Goto到Nested Block当中的Lable
	3.不能够Goto到另外一个Loop语句当中的Lable
	4.不能够从一个Excption的hanlder当中跳出到当前的block语句中
	5.但是能够从一个Nested的Block当中跳出来
	

