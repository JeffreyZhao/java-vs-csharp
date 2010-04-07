package jeffz.generics;

import java.util.Map;

public class EntityUtil {

	// we cannot do like this
	public static <T> T clone(T entity) {
		// T result = new T();
		return null;
	}
	
	public static <T> T clone(T entity, Class<T> type) throws Exception {
		T result = (T)type.newInstance();
		// clone internals
		return result;
	}
	
	public static void main (String[] args) throws Exception {
		User user = new User();
		
		// we cannot use this.
		User user1 = EntityUtil.clone(user);
		
		// we have to do this
		User user2 = EntityUtil.clone(user, User.class);
	}
}
