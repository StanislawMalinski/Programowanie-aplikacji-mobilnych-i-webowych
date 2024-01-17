import './Paginator.css';

interface PaginatorProps {
    maxPages: number,
    currentPage: number,
    setCurrentPage: (page: number) => void
}

function Paginator(props: PaginatorProps) {
    var pages = [];
    const padding = 2;
    let className;
    
    for (let i = 1; i <= props.maxPages; i++) {
        if ( i <= padding || 
            i > props.maxPages - padding || 
            (i >= props.currentPage - padding && i <= props.currentPage + padding)){
            className = i === props.currentPage ? "paginator-btn paginator-btn-active" : "paginator-btn";
            pages.push(<button className={className} 
                    key={i} 
                    onClick={() => props.setCurrentPage(i)}>{i}</button>);
        } else if (i === padding + 1 || i === props.maxPages - padding) {
            pages.push(<span key={i}>...</span>);
        }
    }

    return (
        <div className="paginator-container">
            {pages}
        </div>
    );
}

export default Paginator;