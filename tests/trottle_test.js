import http from "k6/http";
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '15s', target: 1 }, // below normal load
        // { duration: '5m', target: 100 },
        // { duration: '2m', target: 200 }, // normal load
        // { duration: '5m', target: 200 },
        // { duration: '2m', target: 300 }, // around the breaking point
        // { duration: '5m', target: 300 },
        // { duration: '2m', target: 400 }, // beyond the breaking point
        // { duration: '5m', target: 400 },
        // { duration: '10m', target: 0 }, // scale down. Recovery stage.
    ],
};

const API_BASE_URL = 'https://localhost:44361/api';

export default function () {

    let responses = http.batch([
        ['GET', `${API_BASE_URL}/getdate`]
    ]);

    // sleep(1);
    
    responses.forEach((response) =>  {
        t.expect(response.status)
            .as('response status')
            .toEqual(200);
    });
};

// export default () => {
//     let response = http.get("https://localhost:5001/weather");
//     check(response, {
//         'is status 200': (r) => r.status === 200
//     });
// };
