import { Httpx, Get } from 'https://jslib.k6.io/httpx/0.0.2/index.js';
import { describe } from 'https://jslib.k6.io/expect/0.0.4/index.js';
import { check } from 'k6';

const session = new Httpx({ baseURL: 'https://localhost:44361/api' });

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '5s', target: 1 }, // below normal load
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
export default function () {
    describe('01. Fetch public crocodiles all at once', (t) => {
        const res = session.get('getdate');

        check(res, {
            'response code was 200': (res) => res.status === 200,
        });
    });
}
