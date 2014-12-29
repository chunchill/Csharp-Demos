==Anonymous block==
1.What is an Anonymous Block?
2.Single line and mutline comments
3.Nesting of Anonymous blocks
4.Variable scope and visiblity, label of a block


--不区分大小写

<<NameOfTheBlock>>--标记Block,相当于命名空间，这样内嵌的Block就可以访问得到外部的同名变量
DECLARE

I_counter NUMBER;

BEGIN

I_counter:=1;

EXCEPTION
	WHEN OTHERS THEN 
		null;
END;

BEGIN

null;

END;

：= ,赋值符号
|| ,连接符号
dbms_output.put_line('Hello World')
内嵌变量的生命周期只会仅仅在其范围内

Black Lables

