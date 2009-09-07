% eg [{"f1":1,"f2":2},{"f1":1,"f2":2}]
function sensorsInfo = WSNSensors(domain)
    
    json = urlread(strcat(domain,'/WSNSensors'));
    data = parse_json(json);

    sensorsInfo = data{1,1};
end