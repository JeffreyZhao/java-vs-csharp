package jeffz.tests;

import org.easymock.*;
import static org.easymock.EasyMock.*;

public class EasyMockTest {
	public static void main(String[] args) {
		IMocksControl control = createControl();
		
		Calculator mockObj = control.createMock(Calculator.class);
		expect(mockObj.add(1, 2)).andReturn(3);
		expect(mockObj.add(4, 5)).andReturn(9);
		expect(mockObj.divide(0, isA(Integer.class))).andReturn(0);
		
		control.replay();
		
		// pass to other methods
		
		control.verify();
	}
}
