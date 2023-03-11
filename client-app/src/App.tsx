import { useEffect, useState } from 'react'
import 'semantic-ui-css/semantic.min.css';
import './App.css'
import axios from 'axios';
import { Activity } from './types/activity';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState<Activity[] | null>(null);

  useEffect(() => {
    axios.get<Activity[]>('http://localhost:3333/api/activities')
      .then((response) => response.data)
      .then((data) => setActivities(data));
  }, []);

  activities && console.dir(activities);

  return (
    <div>
      <Header as="h2" icon="users" content="Reactive" />
      <List>
        {activities && activities.map((activity) => (
          <List.Item key={activity.id}>{activity?.title}</List.Item>
        ))}
      </List>
    </div>
  )
}

export default App
