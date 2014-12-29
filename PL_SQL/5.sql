==CURSORS==
	--Implicit cursor
	--Explicit cursor
	--Cursor Loops
	--Cursor For Update
	--Cursor Variable
	
	==Life Cycle Of Cursor==
		OPEN->Fetch->Close
	=========================SETUP=============================
	CREATE TABLE departments(
	depet_id NUMBER NOT NULL PRIMARY KEY,
	dept_name Varchar2(60)
	);
	
	CREATE TABLE employee(
	emp_id NUMBER NOT NULL PRIMARY KEY,
	emp_name Varchar2(60),
	dept_id NUMBER,
	emp_loc Varchar2(60),
	emp_sal NUMBER,
	CONSTRAINT emp_dept_fk FOREIGN KEY(emp_dept_id) REFERENCES departments(depet_id));
	===========================================================
	
	==Implicit Cursors==
		--Implicit Cursors在我们触发SELECT,UPDATE,INSERT,DELETE的时候就会打开
		--Implicit limitation,在使用Implicit cursors 在使用Update,Delelte的时候没有什么需要特别注意的；
			--然而，在和Select语句时候的时候就需要特别注意，必须保证只有“一条”数据返回，主要用来判断“存在性”的；
			--如果数据不存在或者多于一条都会报错
	===========================================================
		DECLARE
			I_dept_id departments.depet_id%TYPE;
			I_dept_name departments.dept_name%TYPE;
		BEGIN
			SELECT dept_id,
				   dept_name
			  INTO I_dept_id,I_dept_name 
			  FROM departments 
			WHERE depet_id=1;
			IF SQL%FOUND THEN --SQL%FOUND is a built-in implicit cursor attribute, returns boolean value;
							  --The similar one is SQL%NOTFOUND
				DBMS_OUTPUT.PUT_LINE(SQL%ROWCOUNT);--SQL%ROWCOUNT is a built-in implicit cursor attribute
			END IF
		END;
	===========================================================
		BEGIN
			DELETE FROM departments;
			IF SQL%FOUND THEN
				DBMS_OUTPUT.PUT_LINE(SQL%ROWCOUNT);
			END IF;
		END;
		
		BEGIN
			UPDATE FROM departments
				SET dept_name='Marketing'
				WHERE dept_id=2;
			IF SQL%FOUND THEN
				DBMS_OUTPUT.PUT_LINE(SQL%ROWCOUNT);
			END IF;
		END;
		
	===========================================================
		
	==Explicit Cursors==
		CURSOR <CURSOR_NAME> IS SELECT_STATEMENT;
	===========================================================
		DECLARE
			I_dept_id departments.depet_id%TYPE;
			I_dept_name departments.dept_name%TYPE;
			CURSOR cur_get_department IS
				SELECT dept_id,
					   dept_name
					FROM departments
					WHERE depet_id=1;
		BEGIN
			OPEN cur_get_department;
			FETCH cur_get_department
				INTO I_dept_id,
					 I_dept_name;
			DBMS_OUTPUT.PUT_LINE(I_dept_name);
			CLOSE cur_get_department;
		END;
	=================MUTIL ROW SELECT=========================
		DECLARE
			CURSOR cur_get_employees IS
				SELECT emp_id,
					   emp_sal*0.01 bonus
					FROM cur_get_employees;
			cur_get_employees_var cur_get_employees%ROWTYPE; --<CURSOR>%ROWTYPE
		BEGIN
			OPEN cur_get_employees;
			LOOP
				FETCH cur_get_employees
					INTO cur_get_employees_var;
				EXIT WHEN cur_get_employees%NOTFOUND;--<cusor_name>%NOTFOUND;<cusor_name>%FOUND;
					DBMS_OUTPUT.PUT_LINE(cur_get_employees_var.emp_id);
					DBMS_OUTPUT.PUT_LINE(cur_get_employees_var.bonus);
			END LOOP;
				CLOSE cur_get_employees;
		END;
	===========================================================
		DECLARE
			CURSOR cur_get_employees IS
				SELECT emp_id,
					   emp_sal*0.01 bonus
					FROM cur_get_employees;
			cur_get_employees_var cur_get_employees%ROWTYPE; --<CURSOR>%ROWTYPE
		BEGIN
			OPEN cur_get_employees;
			LOOP
				FETCH cur_get_employees
					INTO cur_get_employees_var;
				EXIT WHEN cur_get_employees%NOTFOUND;--<cusor_name>%NOTFOUND;<cusor_name>%FOUND;
					DBMS_OUTPUT.PUT_LINE(cur_get_employees%ROWCOUNT)--在刚ROWCOUNT随着每次Fetch增加1，刚打开CURSOR的时候为0,只能在打CURSOR和关闭CURSOR前访问该变量
			END LOOP;
			IF cur_get_employees%ISOPEN THEN--<cusor_name>%ISOPEN,不能尝试打开已经打开或者已经关闭状态的CURSOR
				CLOSE cur_get_employees;
			END IF;
		END;
	===================CURSOR PARAMETERS=======================
		CURSOR <cusor_name>[(param1,param2...paramN)] IS
		SELECT_STATEMENT;
		
		param_name datatype [default]
	===========================================================
		DECLARE
			CURSOR cur_get_departments(p_rows NUMBER DEFAULT 5) IS
				SELECT dept_id,
					   dept_name
					FROM departments
					WHERE ROWNUM<=p_rows;
			cur_get_departments_var cur_get_departments%ROWTYPE; --<CURSOR>%ROWTYPE
		BEGIN
			OPEN cur_get_departments(2);
			LOOP
				FETCH cur_get_departments
					INTO cur_get_departments_var;
				EXIT WHEN cur_get_departments%NOTFOUND;
			END LOOP;		
			CLOSE cur_get_departments;
		END;
	=====================CURSOR FOR LOOP=======================
	FOR cur_rec IN <cursor_name or sql_query> LOOP --Automatic open & close,implicit CURSOR%ROWTYPE Record Variable
		STATMENTS;
	END LOOP;
	========================cursor_name========================
		DECLARE
			CURSOR cur_get_employees IS
				SELECT emp_id,
					   emp_sal*0.01 bonus
					FROM cur_get_employees;
		BEGIN
			FOR cur_get_employees_var IN cur_get_employees LOOP
				DBMS_OUTPUT.PUT_LINE(cur_get_employees_var.emp_id);
				DBMS_OUTPUT.PUT_LINE(cur_get_employees_var.bonus);
			END LOOP;
		END;
	========================sql_query==========================
		DECLARE
			I_num NUMBER:=2;
		BEGIN
			FOR cur_get_departments_var IN (
				SELECT dept_id,
				   dept_name
					FROM departments
				WHERE ROWNUM<=I_num;
			) LOOP
				DBMS_OUTPUT.PUT_LINE(cur_get_departments_var.dept_id);	 
			END LOOP;
		END;
	=======================NESTED CURSOR========================
		DECLARE
			CURSOR cur_get_dept_info(p_rownum NUMBER) IS
				SELECT depet_id
					FROM departments
					WHERE ROWNUM<=p_rownum;
			
			CURSOR cur_get_emp_info(p_dept_id departments.depet_id%TYPE) IS
				SELECT emp_name
					FROM employee
					WHERE emp_dept_id=p_dept_id;
		BEGIN
			<<dept_loop>>
			FOR cur_get_dept_info_var in cur_get_dept_info(2) LOOP
				DBMS_OUTPUT.PUT_LINE('Dept id: '|| cur_get_dept_info_var.depet_id);
				<<emp_loop>>
				FOR cur_get_emp_info_var in cur_get_emp_info(cur_get_dept_info_var.depet_id) LOOP
					DBMS_OUTPUT.PUT_LINE('Emp Name: '|| cur_get_emp_info_var.emp_name);
				END LOOP emp_loop;
			END LOOP dept_loop;
		END;
	=====================CURSOR FOR UPDATE=====================
		CURSOR <curson_name>[(param1,param2,paramN)] IS
			SELECT_STATEMENT FOR UPDATE [of column list][NOWAIT]--NOWAIT Tells oracle come back immediately with a notification if the table is already locked by another session
			
		<update_or_delete_stmt> WHERE CURRENT OF <curson_name>
	======================= EXAMPLE ===========================
		DECLARE
			CURSOR cur_move_emp(p_emp_loc employee.emp_loc%TYPE) IS
				SELECT emp_id,dept_name
					FROM departments,
					     employee
					WHERE emp_dept_id=depet_id
						AND emp_loc=p_emp_loc
			FOR UPDATE OF emp_loc NOWAIT; --只会LOCK employee table，而不会Lock departments table
		BEGIN
			FOR cur_move_emp_var IN cur_move_emp('CA') LOOP
				UPDATE employee
					SET emp_loc='WA'
				WHERE CURRENT OF cur_move_emp;
			END LOOP;
			COMMIT;--It's very important COMMIT here, for the lock issue;
		END;
	=========================REF CURSOR/CURSOR VARIABLES=======
	--Strongly Typed Cursor VARIABLES,不同的ref_cur_name变量即使返回的类型一样，也是不可以相互赋值的
		TYPE <ref_cur_name> IS REF CURSOR [RETURN return_type]--Ref Cursor不能够用来For..Loop，只能用来打开，或者关闭,Fetch
	=================== EXAMPLE ===============================
		DECLARE
			TYPE rc_dept IS REF CURSOR RETURN departments%ROWTYPE;--Return type,也可以Return我们自己定义的Record TYPE
			rc_dept_cur rc_dept;
			l_dept_rowtype departments%ROWTYPE;
			l_id	departments.id%TYPE:=1;
			l_dept_id	departments.dept_id%TYPE;
			l_dept_name departments.dept_name%TYPE;
		BEGIN
			OPEN rc_dept_cur FOR --OPEN <cursor_name> FOR QUERY
				SELECT * FROM departments
					WHERE dept_id=l_id;
			l_id:=2;
			LOOP
				FETCH rc_dept_cur INTO l_dept_rowtype;
				EXIT WHEN rc_dept_cur%NOTFOUND;
				DBMS_OUTPUT.PUT_LINE(l_dept_rowtype.dept_id);
			END LOOP;
			
			OPEN rc_dept_cur FOR
				SELECT * FROM departments
					WHERE dept_name='Accounting';
			LOOP
				FETCH rc_dept_cur INTO l_dept_id,l_dept_name;
				EXIT WHEN rc_dept_cur%NOTFOUND;
				DBMS_OUTPUT.PUT_LINE(l_dept_id.dept_id);
			END LOOP;
			CLOSE rc_dept_cur;
		END;
	
	==============WEAKLY TYPED CURSOR VARIABLES,EXAMPLE 1==
		DECLARE
			TYPE rc_weak IS REF CURSOR;
			rc_weak_cur rc_weak;
			l_dept_rowtype departments%ROWTYPE;
			l_emp_rowtype employee%ROWTYPE;
		BEGIN
			OPEN rc_weak_cur FOR
				SELECT * FROM departments
					WHERE dept_id=1;
			Loop
				FETCH rc_weak_cur into l_dept_rowtype;
				EXIT WHEN rc_weak_cur%NOTFOUND;
				DBMS_OUTPUT.PUT_LINE(l_dept_rowtype.dept_name);
			END LOOP;
			
			OPEN rc_weak_cur FOR
				SELECT * FROM employee
					WHERE emp_dept_id=2;
			Loop
				FETCH rc_weak_cur INTO l_emp_rowtype;
				EXIT WHEN rc_weak_cur%NOTFOUND;
				DBMS_OUTPUT.PUT_LINE(l_emp_rowtype.emp_name);
			END LOOP;
			IF rc_weak_cur%ISOPEN THEN
				CLOSE rc_weak_cur;
			END IF;
		END;
		==============WEAKLY TYPED CURSOR VARIABLES,EXAMPLE 2==
		DECLARE
			TYPE rc_weak IS REF CURSOR;
			rc_weak_cur rc_weak;
			rc_sys_cur SYS_REFCURSOR;--SYS_REFCURSOR is defined by oracle
			l_dept_rowtype departments%ROWTYPE;
			l_lower NUMBER:=1;
			l_upper NUMBER:=10;
		BEGIN
			OPEN rc_sys_cur FOR
				SELECT * FROM departments
					WHERE dept_id=1 BETWEEN :1 AND :2 USING l_lower,l_upper; --(:1,:2 are placeholder)
			rc_weak_cur:=rc_sys_cur;
			Loop
				FETCH rc_weak_cur into l_dept_rowtype;
				EXIT WHEN rc_weak_cur%NOTFOUND;
				DBMS_OUTPUT.PUT_LINE(l_dept_rowtype.dept_name);
			END LOOP;
		
			IF rc_weak_cur%ISOPEN THEN
				CLOSE rc_weak_cur;
			END IF;
		END;
		
		========================CURSOR EXPRESSION================
		CURSOR(QUERY)
		--nested dataset;outer selct column;closure
		
		DECLARE
			CURSOR cur_dept_info IS
				SELECT dept_id,CURSOR(SELECT emp_id	
					FROM employee
						WHERE emp_dept_id=dept_id) emp_info--emp_info is alias for the nested cursor
				FROM departments;
			l_dept_id departments.dept_id%TYPE;
			re_emp_info SYS_REFCURSOR;
			l_emp_id employee.emp_id%TYPE;
		BEGIN
			OPEN cur_dept_info;
			Loop
				FETCH cur_dept_info into l_dept_id,re_emp_info;
				EXIT WHEN cur_dept_info%NOTFOUND;
					LOOP
						FETCH re_emp_info INTO l_emp_id;
						EXIT WHEN re_emp_info%NOTFOUND;
						DBMS_OUTPUT.PUT_LINE('l_emp_id： '||l_emp_id);
					END Loop;
			END LOOP;
			CLOSE cur_dept_info;--当关闭该Cursor的时候，它会同时关闭其Nested的CURSOR
		END;
		
		
		