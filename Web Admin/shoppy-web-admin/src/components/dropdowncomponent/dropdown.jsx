import * as React from 'react';
import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import PropTypes from 'prop-types';
import { MenuItem } from '@mui/material';

export function DropDownComponent({ title, options }) {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div>
      <Button
        id="basic-button"
        aria-controls={open ? 'basic-menu' : undefined}
        aria-haspopup="true"
        aria-expanded={open ? 'true' : undefined}
        onClick={handleClick}
        sx={{ textTransform: 'initial' }}
      >
        {title ?? "Menu"}
      </Button>
      <Menu
        id="basic-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{
          'aria-labelledby': 'basic-button',
        }}
      >
        {options && options.map((item, index) => (
          <MenuItem key={index} onClick={() => { handleClose(); item.handleClick(); }}>{item.title}</MenuItem>
        ))}
      </Menu>
    </div>


  );
}


export default function DropdownCustomComponent({ title, options, className }) {
  return (
    <div className={`dropdown d-block my-2 ${className}`}>
      <button className="btn btn-sm btn-secondary dropdown-toggle px-3 me-3" type="button" id={`dropdown-${title}`} data-bs-toggle="dropdown" aria-expanded="false">
        {title ?? "Menu"}
      </button>
      <ul className="dropdown-menu" aria-labelledby={`dropdown-${title}`}>
        {options && options.map((item, index) => (
          <li key={index}><button className="dropdown-item" onClick={item.handleClick}>{item.title}</button></li>
        ))}
      </ul>
    </div>
  )
}

DropDownComponent.propTypes = {
  title: PropTypes.string.isRequired,
  options: PropTypes.arrayOf(
    PropTypes.shape({
      title: PropTypes.string.isRequired,
      handleClick: PropTypes.func.isRequired
    })
  ).isRequired
};

DropdownCustomComponent.propTypes = {
  title: PropTypes.string.isRequired,
  options: PropTypes.arrayOf(
    PropTypes.shape({
      title: PropTypes.string.isRequired,
      handleClick: PropTypes.func.isRequired
    })
  ).isRequired,
  className: PropTypes.element
};
