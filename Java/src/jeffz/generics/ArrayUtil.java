package jeffz.generics;

import java.lang.reflect.Array;
import java.util.*;

public class ArrayUtil {
	public static <T> T[] convert(List<T> list) {
		// you can't do this
		// return new T();
		return null;
	}
	
	// you have to pass another class parameter
	@SuppressWarnings("unchecked")
	public static <T> T[] convert(List<T> list, Class<T> componentType) {
		T[] array = (T[])Array.newInstance(componentType, list.size());
		for (int i = 0; i < array.length; i++) {
			array[i] = list.get(i);
		}
		return array;
	}
	
	public void main(String[] args) {
		List<Integer> list = new ArrayList<Integer>();
		Integer[] array = ArrayUtil.convert(list, Integer.class);
	}
}
