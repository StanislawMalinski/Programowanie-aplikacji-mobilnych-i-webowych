import './Paginator.css';

interface PaginatorProps {
    maxPages: number,
    currentPage: number,
    setCurrentPage: (page: number) => void
}

function Paginator(props: PaginatorProps) {
    var pages = [];
    for (let i = 1; i <= props.maxPages; i++) {
        pages.push(<button className="paginator-btn" 
                key={i} 
                onClick={() => props.setCurrentPage(i)}>{i}</button>);
    }

    return (
        <div className="paginator-container">
            {pages}
        </div>
    );
}

export default Paginator;