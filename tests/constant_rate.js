import http from 'k6/http';
import { check } from 'k6';

export const options = {
  scenarios: {
    constant_request_rate: {
      executor: 'constant-arrival-rate',
      rate: 100,
      timeUnit: '60s', // 1000 iterations per second, i.e. 1000 RPS
      duration: '3m',
      preAllocatedVUs: 1, // how large the initial pool of VUs would be
      maxVUs: 2, // if the preAllocatedVUs are not enough, we can initialize more
    },
  },
};

export default function () {
  let response = http.get('https://localhost:44361/api/getdate');
  check(response, {
    'is status 200': (r) => r.status === 200
});
}
