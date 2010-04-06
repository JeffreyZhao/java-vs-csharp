package jeffz.annotations;

public @interface CustomValidator {
	Class<? extends Validator> value();
}
