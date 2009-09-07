% eg {"f1":1,"f2":2}
function [value,dateTime] = WSNLastReading(domain,sensorID)
    json = urlread(strcat(domain,'/WSNLastReading?sensorID=',sensorID));
    data = parse_json(json);

    value = data{1,1}.value;
    dateTime = data{1,1}.dateTime;
end