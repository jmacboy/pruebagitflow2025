package context;

import java.util.HashMap;
import java.util.Map;
import java.util.Map;
import java.util.Properties;

public class World {
    public static Properties envConfig;
    public Map<String, Object> featureContext;
    public Map<String, Object> scenarioContext = new HashMap<>();
    public static ThreadLocal<HashMap<String, Object>> threadLocal= new ThreadLocal<>();
}