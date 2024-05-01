import {useEffect, useState} from 'react';
import {Container} from 'react-bootstrap';
import {Link, Navigate} from 'react-router-dom';

const NotFoundPage = () => {
    const [redirectionCountDown, setRedirectionCountDown] = useState<number>(5);

    useEffect(() => {
        setTimeout(() => setRedirectionCountDown(redirectionCountDown - 1), 1000);
    });

    return (
        redirectionCountDown < 1
            ? <Navigate to="/"/>
            : <main className="page notfound-page">
                <Container fluid={false}>
                    <div className="page-wrapper">
                        <div className="flex-shield">
                            <h2 className="notfound-number">404</h2>
                            <p className="notfound-description">
                                <b>Error 404</b> Page not found
                            </p>
                            <Link to="/" className="redirect-home">
                                Take me back home {redirectionCountDown}
                            </Link>
                        </div>
                    </div>
                </Container>
            </main>
    );
};

export default NotFoundPage;