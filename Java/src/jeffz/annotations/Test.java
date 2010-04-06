package jeffz.annotations;

import java.lang.annotation.Annotation;

public class Test {
	public static void main(String[] args) {
		RegexValidation regexValidation = new RegexValidation() {
			public String value() {
				return "<[^>*]>";
			}

			@Override
			public Class<? extends Annotation> annotationType() {
				// TODO Auto-generated method stub
				return null;
			}
		};
		
		RangeValidation rangeValidation = new RangeValidation() {
			public int min() {
				return 20;
			}
			public int max() {
				return 30;
			}
			@Override
			public Class<? extends Annotation> annotationType() {
				// TODO Auto-generated method stub
				return null;
			}
		};
	}	
}
