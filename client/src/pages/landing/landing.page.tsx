// pkgs:

// utils:
import InitialSliceComponent from '../../components/base/initial.comp';
import PagesHero from '../../components/hero/hero.comp';
import './style.sass';

// component>>>
const LandingPage = () => {
  const heroHeading = `Start to build awesome apps, And be more productive`;
  const heroDescription = `There is no need for writing boring boilerplate any more :)`;

  return (
    <main className="page landing-page">
      {/* hero */}
      <PagesHero heading={heroHeading} description={heroDescription}></PagesHero>
      <InitialSliceComponent />
    </main>
  );
};

export default LandingPage;