/*
  Soak testing is used to validate reliability of the system over a long time

  Run a soak test to:
  - Verify that your system doesn't suffer from bugs or memory leaks, which result in a crash or restart after several hours of operation
  - Verify that expected application restarts don't lose requests
  - Find bugs related to race-conditions that appear sporadically
  - Make sure your database doesn't exhaust the allotted storage space and stops
  - Make sure your logs don't exhaust the allotted disk storage
  - Make sure the external services you depend on don't stop working after a certain amount of requests are executed

  How to run a soak test:
  - Determe the maximum amount of users your system can handle
  - Get the 75-80% of that value
  - Set VUs to that value
  - Run the test in 3 stages. Rump up to the VUs, stay there for 4-12 hours, rump down to 0
*/

import http from "k6/http";
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
      { duration: '2m', target: 400 }, // ramp up to 400 users
      { duration: '3h56m', target: 400 }, // stay at 400 for ~4 hours
      { duration: '2m', target: 0 }, // scale down. (optional)
    ],
  };

  const API_BASE_URL = 'https://localhost:5001';

  export default () => {

      http.batch([
        ['GET', `${API_BASE_URL}/youtube`],
        ['GET', `${API_BASE_URL}/github`],
        ['GET', `${API_BASE_URL}/twitter`],
      ]);

      sleep(1);
  };