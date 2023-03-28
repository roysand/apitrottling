import { check } from 'k6';
import http from "k6/http";
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    maxRedirects: 0,
    // vus: 1,
    // duration: '5s',
    noConnectionReuse: false,
    stages: [
        { duration: '10s', target: 1 }, // below normal load
        { duration: '10s', target: 1 },
        // { duration: '2m', target: 1 }, // normal load
        // { duration: '5m', target: 1 },
        // { duration: '2m', target: 1 }, // around the breaking point
        // { duration: '5m', target: 1 },
        // { duration: '2m', target: 1 }, // beyond the breaking point
        // { duration: '5m', target: 1 },
        // { duration: '10m', target: 1 }, // scale down. Recovery stage.
    ],
};
let baseUrl = 'https://localhost:44361/api/getdate';

export default () => {
    let response = http.get(baseUrl);
    check(response, {
        'is status 200': (r) => r.status === 200
    });
    
    sleep(1);
};
