package jeffz.annotations;

public class Person {
	@RangeValidation(min = 10, max = 60)
	public int age;

	@RegexValidation("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$")
	public String email;

     //[Validator(typeof(NameValidator))]
	public String name;
}
