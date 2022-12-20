import React from 'react';
import { Home } from './components';
import { Container } from 'react-bootstrap';

import './custom.css'

export default function App() {
  return <Container>
    <Home />
  </Container>
}
// export default class App extends Component {
//   static displayName = App.name;

//   render() {
//     return (
//       <Layout>
//         <Route exact path='/' component={Home} />
//         <Route path='/counter' component={Counter} />
//         <Route path='/fetch-data' component={FetchData} />
//       </Layout>
//     );
//   }
// }
