package jeffz.generics;

import java.lang.reflect.Array;
import java.util.*;

public class ArrayUtil {

	// you can't do this
	public static <T> T[] convert(List<T> list) {
		// T[] array = new T[list.size()];
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
		
		// we cannot do this
		Integer[] array1 = ArrayUtil.convert(list);
		
		// we have to do this
		Integer[] array2 = ArrayUtil.convert(list, Integer.class);
	}
}
