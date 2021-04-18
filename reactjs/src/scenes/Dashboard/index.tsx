import * as React from 'react';
import { Row, Col, Card } from 'antd';
import './index.less';

export class Dashboard extends React.Component<any> {
  componentDidMount() {
    setTimeout(() => this.setState({ cardLoading: false }), 1000);
  }

  state = {
    cardLoading: true,
  };

  render() {
    const { cardLoading } = this.state;
    return (
      <React.Fragment>
        <Row gutter={16}>
          <Col
            className={'dashboardCard'}
            xs={{ offset: 1, span: 22 }}
            sm={{ offset: 1, span: 22 }}
            md={{ offset: 1, span: 11 }}
            lg={{ offset: 1, span: 11 }}
            xl={{ offset: 0, span: 6 }}
            xxl={{ offset: 0, span: 6 }}
          >
            <Card
              className={'dasboardCard-ticket'}
              bodyStyle={{ padding: 50 }}
              loading={cardLoading}
              bordered={false}
            >
              Welcome to elevation hotel admin portal
            </Card>
          </Col>
        </Row>
      </React.Fragment>
    );
  }
}

export default Dashboard;
