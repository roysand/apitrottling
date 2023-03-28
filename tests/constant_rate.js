import http from 'k6/http';
import { check } from 'k6';

export const options = {
  scenarios: {
    constant_request_rate: {
      executor: 'constant-arrival-rate',
      rate: 110,
      timeUnit: '60s', // 1000 iterations per second, i.e. 1000 RPS
      duration: '2m',
      preAllocatedVUs: 5, // how large the initial pool of VUs would be
      maxVUs: 10, // if the preAllocatedVUs are not enough, we can initialize more
    },
  },
};

export default function () {
  let response = http.get('https://localhost:6000/api/getdate');
  check(response, {
    'is status 200': (r) => r.status === 200
});
}
