package jeffz.tests;

public class EasyMockTest {
	public static void main(String[] args) {
		Calculator mockObj = createMock(Calculator.class);
		expect(mockObj.add(1, 2)).andReturn(3);
		expect(mockObj.add(4, 5)).andReturn(9);
		expect(mockObj.divide(0, isA(Integer.class))).andReturn(0);
	}
}
