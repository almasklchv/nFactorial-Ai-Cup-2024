const BurgerMenu = () => {
  return (
    <div className="block md:hidden bg-primary p-10">
      <nav className="flex flex-col text-center gap-5">
        <a className="text-white text-[18px]" href="/">
          Home
        </a>
        <a className="text-white text-[18px]" href="#features">
          Who we are
        </a>
        <a className="text-white text-[18px]" href="#pricing">
          Pricing
        </a>
        <button className="m-auto text-primary font-semibold text-base rounded-[33px] bg-white w-[100px] h-[45px]">
          SIGN UP
        </button>
      </nav>
    </div>
  );
};

export default BurgerMenu;
