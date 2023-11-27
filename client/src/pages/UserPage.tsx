import React from 'react';
import { RouteComponentProps, useParams } from 'react-router-dom';

	interface UserPageProps
	extends RouteComponentProps<{
		id: string;
	}> {}

const UserPage: React.FC<UserPageProps> = ({ match }, props) => {
	const { id } = match.params;

	return (
		<div>
			<h1>User Page</h1>
			<p>ID: {id}</p>
		</div>
	);
};

export default UserPage;